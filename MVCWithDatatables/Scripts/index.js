
$(document).ready(function () {

    var oTable = $('#myDataTable').dataTable({
        "serverSide": true,
        "processing": true,
        "ajax": "/Home/AjaxHandler",
        "columns": [
                        {   "name": "Id",
                            "searchable": false,
                            "sortable": false,
                        },
        	            { "name": "Name" },
        	            { "name": "Address" },
        	            { "name": "Town" }
		            ]
    });
});
