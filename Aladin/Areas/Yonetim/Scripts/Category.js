var Category = new function () {
    this.Create = function () {
        $.ajax({
			url: "/Yonetim/category/create",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };

    this.Update = function () {
        $.ajax({
			url: "/Yonetim/category/update",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };
}