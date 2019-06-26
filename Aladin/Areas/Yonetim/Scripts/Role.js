var Role = new function () {
	this.Create = function () {
		$.ajax({
			url: "/Yonetim/role/create",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};

	this.Update = function () {
		$.ajax({
			url: "/Yonetim/role/update",
			type: "POST",
			data: $("#formItems").serialize()
		})
	};
}