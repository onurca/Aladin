var Dues = new function () {
    this.Create = function () {
       $.ajax({
            url: "/admin/dues/create",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };

    this.Update = function () {
       $.ajax({
           url: "/admin/dues/update",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };
}