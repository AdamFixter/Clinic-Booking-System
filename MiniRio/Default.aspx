<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" enableEventValidation="true" CodeBehind="Default.aspx.cs" Inherits="MiniRio.Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row d-flex flex-column mt-3">
        <div id="alerts"></div>
        <div class="d-flex justify-content-between align-items-center p-2">
            <h1>Appointments</h1>
            <div>
                <asp:LinkButton runat="server" class="btn btn-sm btn-primary" ID="archivedAppointments" onClick="openArchivedAppointmentsModal" >Archived</asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-sm btn-success" ID="addAppointment" onClick="openAppointmentModal" >Add</asp:LinkButton>
            </div>
        </div>
        <div>
            <div class="form-group d-flex align-items-center">
                <div class="d-flex">
                    <asp:Label runat="server" class="pr-3" AssociatedControlID="searchDateInput">By date</asp:Label>
                    <asp:TextBox ID="searchDateInput" runat="server" textmode="DateTimeLocal"/>
                </div>
                <div class="d-flex">
                    <asp:TextBox class="ml-2" ID="searchAppointmentInput" runat="server" textmode="Search"/>
                </div>
                <div class="d-flex">
                    <asp:Button ID="SearchBtn" runat="server" OnClick="Search" class="btn btn-sm btn-primary ml-3"  Text="Search"/>
                </div>
            </div>
        </div>
        <asp:GridView ID="AppointmentsGrid" runat="server"
            AutoGenerateColumns="false"
            AllowPaging="true"
            AllowSorting="true"
            OnSorting="AppointmentsGrid_Sorting"
            OnRowDeleting="AppointmentsGrid_RowDeleting"
            OnRowEditing="AppointmentsGrid_RowEditing"
            OnRowUpdating="AppointmentsGrid_RowUpdating"
            OnPageIndexChanging="AppointmentsGrid_PageIndexChanging"
            CssClass="table table-striped table-hover table-bordered">
            <Columns>
                <asp:BoundField DataField="Patient.Name" HeaderText="Patient" SortExpression="Patient" />
                <asp:BoundField DataField="Clinic.Code" HeaderText="Clinic" SortExpression="Clinic" />
                <asp:BoundField DataField="FormattedDate" HeaderText="Time (Start/End)" SortExpression="Date" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" class="btn btn-sm btn-success" ID="ModifyAppointment" CommandArgument='<%# Eval("id") %>' OnClick="ModifyAppointment">Edit</asp:LinkButton>
                        <asp:LinkButton runat="server" class="btn btn-sm btn-danger" ID="DeleteAppointment" CommandArgument='<%# Eval("id") %>' OnClick="CancelAppointment">Cancel</asp:LinkButton>
                    </ItemTemplate>                
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="thead-dark" />
        </asp:GridView>

        <div id="addAppointmentModal" class="modal" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h3 class="modal-title">Add Appointment</h3>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body d-flex flex-column mx-2">
                            <div class="d-flex">
                                <div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentPatient">Patient</asp:Label>
                                        <asp:PlaceHolder ID="appointmentPatient" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentDate">Date</asp:Label>
                                        <asp:TextBox class="w-100" ID="appointmentDate" runat="server" textmode="DateTimeLocal"/>
                                    </div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentUrgency">Urgency</asp:Label>
                                        <asp:PlaceHolder ID="appointmentUrgency" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                                <div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentClinic">Clinic</asp:Label>
                                        <asp:PlaceHolder ID="appointmentClinic" runat="server"></asp:PlaceHolder>
                                    </div>
    <%--                            <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="appointmentClinicSpecialtie">Clinic Specialtie</asp:Label>
                                        <asp:PlaceHolder ID="appointmentClinicSpecialtie" runat="server"></asp:PlaceHolder>
                                    </div>--%>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentDuration">Intended Duration</asp:Label>
                                        <asp:PlaceHolder ID="appointmentDuration" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentType">Type</asp:Label>
                                        <asp:PlaceHolder ID="appointmentType" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                            </div>
                            <div class="d-flex">
                                <div class="d-flex flex-column col-3 p-0">
                                    <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentContactEmail">Email</asp:Label>
                                    <asp:Label class="text-nowrap" runat="server" AssociatedControlID="appointmentContactPhoneNumber">Phone Number</asp:Label>

                                </div>
                                <div class="d-flex flex-column col-9 p-0">
                                    <div class="d-flex justify-content-end">
                                        <asp:TextBox class="w-100" ID="appointmentContactEmail" runat="server" textmode="Email"/>
                                    </div>
                                    <div class="d-flex justify-content-end">
                                        <asp:TextBox class="w-100" ID="appointmentContactPhoneNumber" runat="server" textmode="Phone"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="PostAppointment" class="btn btn-success" runat="server" OnClick="CreateAppointment" Text="Add" />
                        </div>
                    </div>
                </div>
            </div>

        <div id="editAppointmentModal" class="modal" tabindex="-1" role="dialog">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                        <h3 class="modal-title"> <asp:Label runat="server" ID="AppointmentEdit_Title"></asp:Label></h3>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </div>
                        <div class="modal-body d-flex flex-column mx-2">
                            <div class="d-flex">
                                <div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentPatient">Patient</asp:Label>
                                        <asp:PlaceHolder ID="editAppointmentPatient" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentDate">Date</asp:Label>
                                        <asp:TextBox class="w-100" ID="editAppointmentDate" runat="server" textmode="DateTimeLocal"/>
                                    </div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentUrgency">Urgency</asp:Label>
                                        <asp:PlaceHolder ID="editAppointmentUrgency" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                                <div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentClinic">Clinic</asp:Label>
                                        <asp:PlaceHolder ID="editAppointmentClinic" runat="server"></asp:PlaceHolder>
                                    </div>
    <%--                            <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="editAppointmentClinicSpecialtie">Clinic Specialtie</asp:Label>
                                        <asp:PlaceHolder ID="editAppointmentClinicSpecialtie" runat="server"></asp:PlaceHolder>
                                    </div>--%>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentDuration">Intended Duration</asp:Label>
                                        <asp:PlaceHolder ID="editAppointmentDuration" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div class="form-group m-1" style="flex-grow: 1;">
                                        <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentType">Type</asp:Label>
                                        <asp:PlaceHolder ID="editAppointmentType" runat="server"></asp:PlaceHolder>
                                    </div>
                                </div>
                            </div>
                            <div class="d-flex">
                                <div class="d-flex flex-column col-3 p-0">
                                    <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentContactEmail">Email</asp:Label>
                                    <asp:Label class="text-nowrap" runat="server" AssociatedControlID="editAppointmentContactPhoneNumber">Phone Number</asp:Label>

                                </div>
                                <div class="d-flex flex-column col-9 p-0">
                                    <div class="d-flex justify-content-end">
                                        <asp:TextBox class="w-100" ID="editAppointmentContactEmail" runat="server" textmode="Email"/>
                                    </div>
                                    <div class="d-flex justify-content-end">
                                        <asp:TextBox class="w-100" ID="editAppointmentContactPhoneNumber" runat="server" textmode="Phone"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                            <asp:Button id="UpdateAppointmentBtn" class="btn btn-success" runat="server" Text="Save" OnClick="UpdateAppointment"/>
                        </div>
                    </div>
                </div>
            </div>

        <div id="deleteAppointmentModal" class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title">Are you sure?</h3>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                        <asp:Button id="DeleteAppointmentBtn" class="btn btn-success" runat="server" Text="Yes" OnClick="ArchiveAppointment"/>
                    </div>
                </div>
            </div>
        </div>
        <div id="archivedAppointmentsModal" class="modal" tabindex="-1" role="dialog">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Are you sure?</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div id="alerts-archived"></div>
                            <asp:GridView ID="AppointmentsArchivedGrid" runat="server"
                                AutoGenerateColumns="false"
                                AllowPaging="true"
                                AllowSorting="true"
                                OnRowDeleting="AppointmentsArchivedGrid_RowDeleting"
                                OnPageIndexChanging="AppointmentsArchivedGrid_PageIndexChanging"
                                OnSorting="AppointmentsArchivedGrid_Sorting"
                                CssClass="table table-striped table-hover table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="Patient.Name" HeaderText="Patient"  SortExpression="Patient.Name" />
                                    <asp:BoundField DataField="Clinic.Code" HeaderText="Clinic"  SortExpression="Clinic.Code" />
                                    <asp:BoundField DataField="FormattedDate" HeaderText="Time (Start/End)"  SortExpression="Date" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" class="btn btn-sm btn-info" ID="UndoAppointmentBtn" CommandArgument='<%# Eval("id") %>' OnClick="UndoAppointment">UNDO</asp:LinkButton>
                                        </ItemTemplate>                
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
