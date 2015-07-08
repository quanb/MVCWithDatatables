
$(document).ready(function () {

    var oTable = $('#myDataTable').dataTable({
        "serverSide": true,
        "processing": true,
        "ajax": "/Home/AjaxHandler",
    	//"aoColumns": [
        //                {   "sName": "ID",
        //                    "bSearchable": false,
        //                    "bSortable": false,
        //                    "fnRender": function (oObj) {
        //                        return '<a href=\"Company/Details/' + oObj.aData[0] + '\">View</a>';
        //                    }
        //                },
		//	            { "sName": "COMPANY_NAME" },
		//	            { "sName": "ADDRESS" },
		//	            { "sName": "TOWN" }
		//            ]
    });
});
