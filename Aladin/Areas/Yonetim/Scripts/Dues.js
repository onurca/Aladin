var Dues = new function () {
    this.Create = function () {
       $.ajax({
		   url: "/Yonetim/dues/create",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };

    this.Update = function () {
       $.ajax({
		   url: "/Yonetim/dues/update",
            type: "POST",
            data: $("#formItems").serialize()
        })
    };
}