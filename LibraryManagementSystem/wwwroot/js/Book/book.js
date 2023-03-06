let deleteModal = "#deleteModal";
let modalTitle = "Delete Book";
$(document).ready(() => {
    let bookTable = $('#book-table').dataTable({
        destroy: true,
        "serverSide": true,
        sorting: false,
        ajax: {
            url: "Book/BookDataTable",
            type: 'POST',
            datatype: "Json",
        },
        "columns": [
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "title",
                "name" : "Title",
            },
            {
                "data": "author",
                "name": "Author",
            },
            {
                "data": "publisher",
                "name": "publisher",
            },
            {
                "data": "publishedDateString",
                "name": "PublishDate",
            },
            {
                "data": "isbn",
                "name": "isbn",
            },
            {
                "data": null,
                render: function (data, type, full) {
                    return `<div class="dropdown">
                                 <button type="button" class="btn jaoas-view-icon" role="button" id="dropdownMenuLink"
                                    data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="fas fa-cog" aria-hidden="true"></i>
                                </button>
                                <div class="dropdown-menu" id="actionBtn" aria-labelledby="dropdownMenuLink">
                                    <a class="dropdown-item" href="/Book/EditBook/${full.bookId}">Edit</a>
                                    <a class="dropdown-item" href="/Book/ViewBook/${full.bookId}">View</a>
                                    <a class="dropdown-item" href="#" onclick="showDeleteModal(${full.bookId})">Delete</a>
                                </div>
                            </div>`
                },
                className: "textcenter",
            }
        ]
    })
})