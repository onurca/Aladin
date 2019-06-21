var User = new function () {
	this.Create = function () {
		$.ajax({
			url: "/admin/user/create",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};

	this.Update = function () {
		$.ajax({
			url: "/admin/user/update",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};

	this.UpdateRoles = function () {
		$.ajax({
			url: "/admin/UserInRole/update",
			type: "POST",
			data: $("#formItems").serialize()
		})
	}
}