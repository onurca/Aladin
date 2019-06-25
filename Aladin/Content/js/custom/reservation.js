var Aladin = Aladin || {};
Aladin.Reservation = new function () {
	this._init = function () {
		$("#check-availability").on("click", function () {
			Aladin.Reservation.Check();
		})
	};

	this.Check = function () {
		var dateIn = $("#date-in").val();
		var dateOut = $("#date-out").val();
		var adultCount = Number($("#adult-count").val());
		var childCount = Number($("#child-count").val());

		if (dateIn === "" || dateOut === "") return;
		dateIn = moment(new Date(dateIn).toLocaleDateString("en-US")).format("YYYY-MM-DD");
		dateOut = moment(new Date(dateOut).toLocaleDateString("en-US")).format("YYYY-MM-DD");
		var url = "https://tr.hotels.com/ho697312416/?pa=1&tab=description&q-check-out=" + dateOut + "&q-check-in=" + dateIn + "&q-room-0-adults=" + adultCount + "&q-room-0-children=" + childCount;

		var win = window.open(url, '_blank');
		win.focus();
	};
}()

Aladin.Reservation._init();