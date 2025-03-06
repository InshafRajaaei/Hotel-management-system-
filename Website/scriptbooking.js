window.addEventListener('load', function () {
  document.body.classList.add('loaded');
});

document.getElementById('bookingForm').addEventListener('submit', async (e) => {
  e.preventDefault();

  const booking = {
      name: document.getElementById('name').value,
      contact: document.getElementById('contact').value,
      email: document.getElementById('email').value,
      checkInDate: document.getElementById('checkInDate').value,
      checkOutDate: document.getElementById('checkOutDate').value,
      guests: document.getElementById('guestId').value,
      roomType: document.getElementById('roomId').value,
      roomCount: document.getElementById('roomCount').value,
      specialRequests: document.getElementById('requests').value
  };

  try {
      const response = await fetch('http://localhost:3000/bookings', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(booking)
      });

      if (response.ok) {
          alert('Booking confirmed!');
          document.getElementById('bookingForm').reset();
      } else {
          alert('Booking failed. Please try again.');
      }
  } catch (error) {
      console.error('Error:', error);
      alert('Booking failed. Please check your connection.');
  }
});