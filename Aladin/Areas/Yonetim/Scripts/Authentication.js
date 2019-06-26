var Authentication = new function () {
	this.Login = function () {
		$.ajax({
			url: "/Yonetim/authentication/login",
			type: "POST",
			data: $("#formItems").serialize()
		});
	};

	this.Logout = function () {
		$.ajax({
			url: "/Yonetim/authentication/logout",
			type: "GET"
		});
	};

	this.PasswordUpdate = function () {
		$.ajax({
			url: "/Yonetim/authentication/PasswordUpdate",
			type: "POST",
			data: $("#formItems").serialize()
		});
	};
}