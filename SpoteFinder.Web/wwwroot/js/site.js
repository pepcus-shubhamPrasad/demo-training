// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/parkingSpotHub")
    .build();

connection.start().catch(err => console.error('Error: ' + err));

connection.on("SpotAvailabilityChanged", (spotId, isAvailable) => {
    location.reload();
    //alert(`Spot ${spotId} availability updated: ${isAvailable ? "Available" : "Booked"}`);
});

connection.on("ReservationCreated", (reservation) => {
    alert(`New reservation created for spot ID: ${reservation.spotId}`);
});

// Handle real-time updates for spot availability
connection.on("ReceiveSpotAvailabilityUpdate", (spotId, isAvailable) => {
	debugger;
	const slotElement = document.querySelector(`.parking-slot[data-spot-id='${spotId}']`);
	if (slotElement) {
		const actionButton = slotElement.querySelector(".btn");
		const icon = slotElement.querySelector(".slot-icon i");

		// Update slot class and button state
		if (isAvailable) {
			slotElement.classList.remove("booked");
			slotElement.classList.add("available");
			icon.className = "fa fa-check-circle available-icon";
			actionButton.classList.remove("btn-danger");
			actionButton.classList.add("btn-success");
			actionButton.textContent = "Book Now";
			actionButton.disabled = false;
		} else {
			slotElement.classList.remove("available");
			slotElement.classList.add("booked");
			icon.className = "fa fa-times-circle booked-icon";
			actionButton.classList.remove("btn-success");
			actionButton.classList.add("btn-danger");
			actionButton.textContent = "Unavailable";
			actionButton.disabled = true;
		}
	}
});
