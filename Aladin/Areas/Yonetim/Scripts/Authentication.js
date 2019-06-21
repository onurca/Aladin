var Authentication = new function () {
	this.Login = function () {
		$.ajax({
			url: "/admin/authentication/login",
			type: "POST",
			data: $("#formItems").serialize()
		});
	};

	this.Logout = function () {
		$.ajax({
			url: "/admin/authentication/logout",
			type: "GET"
		});
	};

	this.PasswordUpdate = function () {
		$.ajax({
			url: "/admin/authentication/PasswordUpdate",
			type: "POST",
			data: $("#formItems").serialize()
		});
	};
}