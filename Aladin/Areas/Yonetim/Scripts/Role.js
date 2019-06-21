var Role = new function () {
	this.Create = function () {
		$.ajax({
			url: "/admin/role/create",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};

	this.Update = function () {
		$.ajax({
			url: "/admin/role/update",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};
}