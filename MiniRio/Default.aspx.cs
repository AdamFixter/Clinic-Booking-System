using AppointmentContracts;
using AppointmentDataContracts;
using Domain;
using PatientDataContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniRio
{
    public partial class Default : Page
    {
        private ClinicBookingSystemService.ClinicBookingSystemService proxy;
        private IEnumerable<AppointmentDataContract> Appointments;
        private IEnumerable<AppointmentDataContract> AppointmentsArchived;
        private IEnumerable<PatientDataContract> Patients;
        private IEnumerable<ClinicDataContract> Clinics;
        private IEnumerable<AppointmentDurationDataContract> appointmentDurations;
        private IEnumerable<AppointmentUrgencyDataContract> appointmentUrgencies;
        private IEnumerable<AppointmentTypeDataContract> appointmentTypes;

        private DropDownList patientDropdown;
        private DropDownList clinicDropdown;
        private DropDownList urgencyDropdown;
        private DropDownList typeDropdown;
        private DropDownList durationDropdown;

        private DropDownList editPatientDropdown;
        private DropDownList editClinicDropdown;
        private DropDownList editUrgencyDropdown;
        private DropDownList editTypeDropdown;
        private DropDownList editDurationDropdown;

        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";


        private List<object> appointmentDropdowns = new List<object>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.proxy = new ClinicBookingSystemService.ClinicBookingSystemService();

            this.Patients = proxy.GetPatientService().GetPatients();
            this.Clinics = proxy.GetClinicService().GetClinics();
            this.appointmentDurations = proxy.GetAppointmentService().GetAllDurations();
            this.appointmentUrgencies = proxy.GetAppointmentService().GetAllUrgencies();
            this.appointmentTypes = proxy.GetAppointmentService().GetAllTypes();
            this.Appointments = proxy.GetAppointmentService().GetAllAvailable();
            this.AppointmentsArchived = proxy.GetAppointmentService().GetArchived();

            setupFields();
            this.patientDropdown = (DropDownList)appointmentPatient.FindControl("patientDropdown");
            this.clinicDropdown = (DropDownList)appointmentClinic.FindControl("clinicDropdown");
            this.urgencyDropdown = (DropDownList)appointmentUrgency.FindControl("urgencyDropdown");
            this.typeDropdown = (DropDownList)appointmentType.FindControl("typeDropdown");
            this.durationDropdown = (DropDownList)appointmentDuration.FindControl("durationDropdown");

            this.editPatientDropdown = (DropDownList)editAppointmentPatient.FindControl("editPatientDropdown");
            this.editClinicDropdown = (DropDownList)editAppointmentClinic.FindControl("editClinicDropdown");
            this.editUrgencyDropdown = (DropDownList)editAppointmentUrgency.FindControl("editUrgencyDropdown");
            this.editTypeDropdown = (DropDownList)editAppointmentType.FindControl("editTypeDropdown");
            this.editDurationDropdown = (DropDownList)editAppointmentDuration.FindControl("editDurationDropdown");                

            AppointmentsGrid.DataSource = this.Appointments.ToList();
            AppointmentsGrid.DataBind();

            AppointmentsArchivedGrid.DataSource = this.AppointmentsArchived.ToList();
            AppointmentsArchivedGrid.DataBind();

            AppointmentsArchivedGrid.HeaderRow.TableSection = TableRowSection.TableHeader;


        }
        private void updateGrid(List<AppointmentDataContract> appointments = null)
        {
            AppointmentsGrid.DataSource = appointments == null ? this.proxy.GetAppointmentService().GetAllAvailable().ToList() : appointments;
            AppointmentsGrid.DataBind();
        }
        private void setupFields()
        {
            //Create appointment
            addDropdownList("patientDropdown", appointmentPatient, this.Patients.ToList(), "Name", "ID");
            addDropdownList("clinicDropdown", appointmentClinic, this.Clinics.ToList(), "Description", "ID");
            //addDropdownList("clinicSpecialtieDropdown", appointmentClinicSpecialtie, new List<SpecialtieDataContract>() { }, "Description", "ID", "Please select a clinic");
            addDropdownList("durationDropdown", appointmentDuration, this.appointmentDurations.ToList(), "Name", "ID");
            addDropdownList("urgencyDropdown", appointmentUrgency, this.appointmentUrgencies.ToList(), "Name", "ID");
            addDropdownList("typeDropdown", appointmentType, this.appointmentTypes.ToList(), "Name", "ID");

            addDropdownList("editPatientDropdown", editAppointmentPatient, this.Patients.ToList(), "Name", "ID");
            addDropdownList("editClinicDropdown", editAppointmentClinic, this.Clinics.ToList(), "Description", "ID");
            //addDropdownList("editClinicSpecialtieDropdown", editAppointmentClinicSpecialtie, new List<SpecialtieDataContract>() { }, "Description", "ID", "Please select a clinic");
            addDropdownList("editDurationDropdown", editAppointmentDuration, this.appointmentDurations.ToList(), "Name", "ID");
            addDropdownList("editUrgencyDropdown", editAppointmentUrgency, this.appointmentUrgencies.ToList(), "Name", "ID");
            addDropdownList("editTypeDropdown", editAppointmentType, this.appointmentTypes.ToList(), "Name", "ID");
        }
        private void addDropdownList<T>(string ID, PlaceHolder placeHolder, List<T> data, string textField, string valueField, string defaultField = "Please select")
        {
            DropDownList dropdownList = new DropDownList()
            {
                ID = ID,
                DataTextField = textField,
                DataValueField = valueField,
                DataSource = data,
                AutoPostBack = false,
                ViewStateMode = ViewStateMode.Enabled,
                EnableViewState = true
            };
            dropdownList.Style.Add("width", "100%");
            dropdownList.DataBind();
            dropdownList.Items.Insert(0, defaultField);
            dropdownList.SelectedValue = "0";

            placeHolder.Controls.Add(dropdownList);
        }
        protected void openArchivedAppointmentsModal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#archivedAppointmentsModal').modal()", true);//show the modal
        }
        protected void openAppointmentModal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#addAppointmentModal').modal()", true);//show the modal
        }
        protected void Search(object sender, EventArgs e)
        {
            DateTime? date = null;
            if (!String.IsNullOrEmpty(searchDateInput.Text))
            {
                date = DateTime.Parse(searchDateInput.Text);
            }


            this.updateGrid(this.proxy.GetAppointmentService().Search(searchAppointmentInput.Text, date).ToList());
        }

        protected void CreateAppointment(object sender, EventArgs e)
        {
            int patientID = this.toInt(this.patientDropdown.SelectedValue);
            int clinicID = this.toInt(this.clinicDropdown.SelectedValue);
            int urgencyID = this.toInt(this.urgencyDropdown.SelectedValue);
            int typeID = this.toInt(this.typeDropdown.SelectedValue);
            int durationID = this.toInt(this.durationDropdown.SelectedValue);
            DateTime date = Convert.ToDateTime(appointmentDate.Text);
            string email = appointmentContactEmail.Text;
            string phoneNumber = appointmentContactPhoneNumber.Text;

            PatientDataContract patientContract = this.proxy.GetPatientService().GetPatient(patientID);
            IEnumerable<AppointmentDataContract> foundAppointments = this.Appointments.Where(a => a.Patient.Id == patientID && !a.Archived);
            if (foundAppointments.ToList().Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), $"ShowMessage('alerts', '{patientContract.Name} already has an appointment available!','danger');", true);
            } else
            {
                this.proxy.GetAppointmentService().CreateAppointment(new AppointmentData()
                {
                    Patient = this.proxy.GetPatientService().GetPatientData(patientID),
                    Clinic = this.proxy.GetClinicService().GetClinicData(clinicID),
                    AppointmentUrgencyData = this.proxy.GetAppointmentService().GetUrgencyData(urgencyID),
                    AppointmentTypeData = this.proxy.GetAppointmentService().GetTypeData(typeID),
                    Date = date,
                    Duration = this.proxy.GetAppointmentService().GetDurationData(durationID),
                    Email = email,
                    PhoneNumber = phoneNumber
                });
                this.updateGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), $"ShowMessage('alerts', 'Appointment created for {patientContract.Name}','Success');", true);
            }
        }
        protected void UpdateAppointment(object sender, EventArgs e)
        {
            int ID = this.toInt(UpdateAppointmentBtn.CommandArgument);

            int patientID = this.toInt(editPatientDropdown.SelectedValue);
            int clinicID = this.toInt(editClinicDropdown.SelectedValue);
            int urgencyID = this.toInt(editUrgencyDropdown.SelectedValue);
            int typeID = this.toInt(editTypeDropdown.SelectedValue);
            DateTime date = Convert.ToDateTime(editAppointmentDate.Text);
            int durationID = this.toInt(editDurationDropdown.SelectedValue);
            string email = editAppointmentContactEmail.Text;
            string phoneNumber = editAppointmentContactPhoneNumber.Text;

            this.proxy.GetAppointmentService().UpdateAppointment(new AppointmentData()
            {
                ID = ID,
                Patient = this.proxy.GetPatientService().GetPatientData(patientID),
                Clinic = this.proxy.GetClinicService().GetClinicData(clinicID),
                AppointmentUrgencyData = this.proxy.GetAppointmentService().GetUrgencyData(urgencyID),
                AppointmentTypeData = this.proxy.GetAppointmentService().GetTypeData(typeID),
                Date = date,
                Duration = this.proxy.GetAppointmentService().GetDurationData(durationID),
                Email = email,
                PhoneNumber = phoneNumber
            });

            this.updateGrid();
        }
        protected void ModifyAppointment(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;  // get the link button which trigger the event
            //row.Cells[0].Text;  get the first cell value of the row
            int ID = this.toInt(linkbutton.CommandArgument);
            AppointmentEdit_Title.Text = $"Edit Appointment ({ID})";
            UpdateAppointmentBtn.CommandArgument = $"{ID}";
            AppointmentDataContract appointment = this.proxy.GetAppointmentService().Get(ID);

            //Dropdowns
            editPatientDropdown.SelectedValue = $"{appointment.Patient.Id}";
            editClinicDropdown.SelectedValue = $"{appointment.Clinic.ID}";
            editAppointmentDate.Text = appointment.Date.ToString("yyyy-MM-ddTHH:mm");
            editDurationDropdown.SelectedValue = $"{appointment.Duration.ID}";
            editUrgencyDropdown.SelectedValue = $"{appointment.AppointmentUrgencyData.Id}";
            editTypeDropdown.SelectedValue = $"{appointment.AppointmentTypeData.Id}";
            editAppointmentContactEmail.Text = appointment.Email;
            editAppointmentContactPhoneNumber.Text = appointment.PhoneNumber;
            
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#editAppointmentModal').modal()", true);//show the modal
        }
        protected void AppointmentsGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Updating the index to the one clicked.  
            AppointmentsGrid.EditIndex = e.NewEditIndex;
            this.updateGrid();
        }

        protected void AppointmentsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Updating the index to the one clicked.  
            AppointmentsGrid.EditIndex = e.RowIndex;
            this.updateGrid();
        }
        protected void CancelAppointment(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;
            DeleteAppointmentBtn.CommandArgument = $"{this.toInt(linkbutton.CommandArgument)}";

            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "$('#deleteAppointmentModal').modal()", true);
        }
        protected void ArchiveAppointment(object sender, EventArgs e)
        {
            AppointmentData appointment = this.proxy.GetAppointmentService().GetAppointmentData(this.toInt(DeleteAppointmentBtn.CommandArgument));
            appointment.Archived = true;
            this.proxy.GetAppointmentService().UpdateAppointment(appointment);

            this.updateGrid();
        }



        //Sroting


        public SortDirection SortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }
        protected void AppointmentsGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            //re-run the query, use linq to sort the objects based on the arg.
            //perform a search using the constraints given 
            //you could have this saved in Session, rather than requerying your datastore
            List<AppointmentDataContract> myGridResults = this.Appointments.ToList();


            if (myGridResults != null)
            {
                var param = Expression.Parameter(typeof(AppointmentDataContract), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<AppointmentDataContract, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                if (SortDirection == SortDirection.Ascending)
                {
                    AppointmentsGrid.DataSource = myGridResults.AsQueryable<AppointmentDataContract>().OrderBy(sortExpression).ToList();
                    SortDirection = SortDirection.Descending;
                }
                else
                {
                    AppointmentsGrid.DataSource = myGridResults.AsQueryable<AppointmentDataContract>().OrderByDescending(sortExpression).ToList();
                    SortDirection = SortDirection.Ascending;
                };


                AppointmentsGrid.DataBind();
            }
        }
        protected void AppointmentsArchivedGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            //re-run the query, use linq to sort the objects based on the arg.
            //perform a search using the constraints given 
            //you could have this saved in Session, rather than requerying your datastore
            List<AppointmentDataContract> myGridResults = this.Appointments.ToList();


            if (myGridResults != null)
            {
                var param = Expression.Parameter(typeof(AppointmentDataContract), e.SortExpression);
                var sortExpression = Expression.Lambda<Func<AppointmentDataContract, object>>(Expression.Convert(Expression.Property(param, e.SortExpression), typeof(object)), param);


                if (SortDirection == SortDirection.Ascending)
                {
                    AppointmentsGrid.DataSource = myGridResults.AsQueryable<AppointmentDataContract>().OrderBy(sortExpression).ToList();
                    SortDirection = SortDirection.Descending;
                }
                else
                {
                    AppointmentsGrid.DataSource = myGridResults.AsQueryable<AppointmentDataContract>().OrderByDescending(sortExpression).ToList();
                    SortDirection = SortDirection.Ascending;
                };


                AppointmentsGrid.DataBind();
            }
        }
        protected void AppointmentsGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = AppointmentsGrid.Rows[e.RowIndex].FindControl("ID") as Label;

            //Update stuff

            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            AppointmentsGrid.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            this.updateGrid();
        }
        protected void Clinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList clinicDropdown = (DropDownList) appointmentClinic.FindControl("clinicDropdown");
            //DropDownList clinicSpecialtiesDropdown = (DropDownList) appointmentClinicSpecialtie.FindControl("clinicSpecialtieDropdown");
            //clinicSpecialtiesDropdown.Items.Add(clinicDropdown.SelectedItem.Text);
        }
        protected void AppointmentsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AppointmentsGrid.PageIndex = e.NewPageIndex;
            this.updateGrid();
        }

        private int toInt(string input)
        {
            int output = int.TryParse(input, out output) ? output : -1;
            return output;
        }
        //public static DataTable ToDataTable<T>(this List<T> items)
        //{
        //    var tb = new DataTable(typeof(T).Name);

        //    PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //    foreach (var prop in props)
        //    {
        //        tb.Columns.Add(prop.Name, prop.PropertyType);
        //    }

        //    foreach (var item in items)
        //    {
        //        var values = new object[props.Length];
        //        for (var i = 0; i < props.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item, null);
        //        }

        //        tb.Rows.Add(values);
        //    }

        //    return tb;
        //}



        //Archived Appointments
        protected void UndoAppointment(object sender, EventArgs e)
        {
            LinkButton linkbutton = (LinkButton)sender;
            int ID = this.toInt(linkbutton.CommandArgument);
            AppointmentDataContract appointmentContract = this.proxy.GetAppointmentService().Get(ID);
            AppointmentData appointment = this.proxy.GetAppointmentService().GetAppointmentData(ID);
            bool slotAvailable = this.proxy.GetAppointmentService().GetAllAvailable().Where(a => a.Patient.Id == appointment.Patient.ID || a.Date == appointment.Date ).ToList().Count < 1;

            if (slotAvailable)
            {
                appointment.Archived = false;
                this.proxy.GetAppointmentService().UpdateAppointment(appointment);
            } else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), $"ShowMessage('alerts', `Slot not available for {appointmentContract.Patient.Name}.`,'Danger');", true);
            }
            this.updateGrid();
        }
        protected void AppointmentsArchivedGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AppointmentsArchivedGrid.PageIndex = e.NewPageIndex;
            this.updateGrid();
        }
        protected void AppointmentsArchivedGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Updating the index to the one clicked.  
            AppointmentsArchivedGrid.EditIndex = e.RowIndex;
            //this.updateGrid();
        }

    }
}