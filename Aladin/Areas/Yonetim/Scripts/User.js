var User = new function () {
	this.Create = function () {
		$.ajax({
			url: "/Yonetim/user/create",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};

	this.Update = function () {
		$.ajax({
			url: "/Yonetim/user/update",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};

	this.UpdateRoles = function () {
		$.ajax({
			url: "/Yonetim/UserInRole/update",
			type: "POST",
			data: $("#formItems").serialize()
		})
	}
}