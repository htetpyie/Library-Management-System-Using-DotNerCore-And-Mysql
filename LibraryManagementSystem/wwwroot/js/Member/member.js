$(document).ready(() => {
    let datatable = $('#member-table').DataTable({
        destroy: true,
        serverSide: true,
        ajax: {
            url: "Member/MemberDataTable",
            method: "POST",
            dataType: "Json",
            sorting: false,
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                },
            },
            {
                data: 'firstName',
                name: "FirstaName"
            },
            {
                data: 'lastName',
                name: "lastName"
            },
            {
                data: 'email',
                name: "email"
            },
            {
                data: "phone",
                name: "phone",
            },
            {
                data: "address",
                name: "address",
            },
            {
                data: null,
                render: function (data, type, full) {
                    return `<div class="dropdown">
                                 <button type="button" class="btn jaoas-view-icon" role="button" id="dropdownMenuLink"
                                    data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fas fa-cog" aria-hidden="true"></i>
                                </button>
                                <div class="dropdown-menu" id="actionBtn" aria-labelledby="dropdownMenuLink">
                                    <a class="dropdown-item" href="/Member/EditMember/${full.memberId}">Edit</a>
                                    <a class="dropdown-item" href="/Member/ViewMember/${full.memberId}">View</a>
                                    <a class="dropdown-item" href="#" onclick="showDeleteModal(${full.memberId})">Delete</a>
                                </div>
                            </div>`
                },
                className: "textcenter",
            }

        ]
    })
})