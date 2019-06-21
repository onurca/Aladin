var ViewInRole = new function () {
	this.GetViewsByRoleId = function () {
		$.ajax({
			url: "/admin/ViewInRole/Actions",
			type: "GET",
			data: $("#formItems").serialize(),
			success: function (result) {
				$("#ActionsWithControllerGroupContainer").html(result);
				RunMultiSelect();
			}
		})
	}

	this.UpdateViewsInRole = function () {
	    $.ajax({
	        url: "/admin/ViewInRole/update",
	        type: "POST",
	        data: $("#formItems").serialize()
	    })
	}

	this._Init = function () {
		$("#RoleId").on("change", function () {
			ViewInRole.GetViewsByRoleId();
		});
	}

	$(document).ready(function () {
		ViewInRole._Init();
		ViewInRole.GetViewsByRoleId();
	})
}