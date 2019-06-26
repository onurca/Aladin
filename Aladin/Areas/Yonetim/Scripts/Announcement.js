var Announcement = new function () {
	this.Create = function () {
		if (Fox.Helper.Dropzone.Own.getUploadingFiles().length > 0) {
			Message(HttpStatusCode.BadRequest, "Lütfen dosya yüklenirken bekleyiniz.")
			return;
		}
		$.ajax({
			url: "/Yonetim/announcement/create",
			type: "POST",
			data: $("#formItems").serialize()
		});
	};

	this.Update = function () {
		if (Fox.Helper.Dropzone.Own.getUploadingFiles().length > 0) {
			Message(HttpStatusCode.BadRequest, "Lütfen dosya yüklenirken bekleyiniz.")
			return;
		}
		$.ajax({
			url: "/Yonetim/announcement/update",
			type: "POST",
			data: $("#formItems").serialize()
		});
	};

	this.GetFiles = function () {
		var query = { ReferenceGuid: $("#Announcement_ID").val() }

		$.ajax({
			url: "/Yonetim/File/Get",
			data: query,
			success: function (result) {
				result = JSON.parse(result)["Data"];
				$.each(result, function (key, value) {
					var $downloadButton;

					if ((/\.(gif|jpg|jpeg|tiff|png)$/i).test(value.Extension)) {
						$downloadButton = $("<a href='/Files/{0}' data-lightbox='{1}' download='{1}'><img class='attachment-image' src='/Files/{0}'></img></a>".format(value.GuidName + value.Extension, value.Name, value.Name));
					}
					else {
						$downloadButton = $("<a href='/Files/{0}' download='{1}'><i class='fa fa-file fa-fw'></i>{2}</a>".format(value.GuidName + value.Extension, value.Name, value.Name));
					}
					$("#files").append($downloadButton);
				});
			}
		});
	};
};