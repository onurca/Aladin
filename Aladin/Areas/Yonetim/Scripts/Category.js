var Category = new function () {
    this.Create = function () {
        $.ajax({
            url: "/admin/category/create",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };

    this.Update = function () {
        $.ajax({
            url: "/admin/category/update",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };
}