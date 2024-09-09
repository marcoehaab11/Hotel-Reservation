document.addEventListener('DOMContentLoaded', function () {
    
    compareDates(); 
   
});
function compareDates() {
    const checkInDate = document.getElementById('checkInDate');
    const checkOutDate = document.getElementById('checkOutDate');
    const message = document.getElementById('message');
    const submitButton = document.getElementById('submitbutton');

    const checkIn = new Date(checkInDate.value);
    const checkOut = new Date(checkOutDate.value);

    if (checkOut <= checkIn) {
        message.textContent = 'Check-Out date must be after Check-In date.';
        message.style.color = 'red';
        submitButton.disabled = true;  
    } else {
        message.textContent = '';
        submitButton.disabled = false;
    }
}



