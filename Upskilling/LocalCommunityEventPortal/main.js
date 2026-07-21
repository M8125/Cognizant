// JS Exercise 1: external script file (was inline <script> in index.html)
console.log('Local Community Event Portal script loaded');
// ponytail: alert() on load blocks headless/automated page loads; console.log covers the "runs on load" exercise intent without the modal

// JS Exercise 2: const/let, JS Exercise 8: Event class + prototype method
class CommunityEvent {
    constructor(id, name, date, category, capacity) {
        this.id = id;
        this.name = name;
        this.date = date;
        this.category = category;
        this.capacity = capacity;
        this.registrations = 0;
    }

    checkAvailability() {
        return this.registrations < this.capacity;
    }
}

// JS Exercise 6/7: events array drives the DOM instead of hardcoded markup
let events = [
    new CommunityEvent(1, 'Spring Fair', 'April 12', 'fair', 150),
    new CommunityEvent(2, 'Food Truck Night', 'May 3', 'food', 80),
    new CommunityEvent(3, 'Park Cleanup', 'May 18', 'volunteer', 40),
    new CommunityEvent(4, 'Art Walk', 'June 7', 'art', 100),
    new CommunityEvent(5, 'Charity Run', 'June 21', 'sports', 200),
    new CommunityEvent(6, 'Winter Market', 'December 5', 'fair', 120),
];

// JS Exercise 8: closures - tracks registration counts per category without globals
function makeCategoryTracker() {
    const counts = {};
    return function track(category) {
        counts[category] = (counts[category] || 0) + 1;
        return counts[category];
    };
}
const trackCategoryRegistration = makeCategoryTracker();

// JS Exercise 3: template literals + DOM manipulation render the event cards
function renderEvents(list) {
    const container = document.getElementById('eventsContainer');
    container.innerHTML = '';
    list.forEach(event => {
        const card = document.createElement('div');
        card.className = 'eventCard';
        card.innerHTML = `
            <h3>${event.name}</h3>
            <p>${event.date} - ${event.category}</p>
            <p>${event.checkAvailability() ? 'Spots available' : 'Fully booked'}
               (${event.registrations}/${event.capacity})</p>
        `;
        container.appendChild(card);
    });
}

// JS Exercise 4: function encapsulation - adds a new event to the array
function addEvent(name, date, category, capacity = 50) {
    const id = events.length ? Math.max(...events.map(e => e.id)) + 1 : 1;
    events.push(new CommunityEvent(id, name, date, category, capacity));
    renderEvents(events);
}

// JS Exercise 4/5: registerUser uses try-catch and ++ to bump a counter
function registerUser(eventId) {
    try {
        const event = events.find(e => e.id === eventId);
        if (!event) {
            throw new Error(`Event ${eventId} not found`);
        }
        if (!event.checkAvailability()) {
            throw new Error(`${event.name} is fully booked`);
        }
        event.registrations++;
        trackCategoryRegistration(event.category);
        renderEvents(events);
        return true;
    } catch (err) {
        console.error('Registration failed:', err.message);
        return false;
    }
}

// JS Exercise 4/10: filterEventsByCategory - array.filter + DOM update
function filterEventsByCategory(category) {
    const filtered = category ? events.filter(e => e.category === category) : events;
    renderEvents(filtered);
}

// JS Exercise 9/12: fetch (mocked) + async/await + loading spinner
function mockFetchEvents() {
    return new Promise(resolve => {
        setTimeout(() => resolve(events.map(e => ({ ...e }))), 800); // spread clones each event (Exercise 10)
    });
}

async function loadEventsFromServer() {
    const spinner = document.getElementById('loadingSpinner');
    spinner.textContent = 'Loading events...';
    try {
        const data = await mockFetchEvents();
        renderEvents(data);
        spinner.textContent = `Loaded ${data.length} events.`;
    } catch (err) {
        spinner.textContent = 'Failed to load events.';
    }
}

// JS Exercise 11: form handling - preventDefault, form.elements, inline validation
function handleEventForm(e) {
    e.preventDefault();
    const form = e.target;
    const name = form.elements.eventName.value.trim();
    const date = form.elements.eventDateInput.value;
    const category = form.elements.eventCategory.value;
    const errorBox = document.getElementById('formError');

    if (!name || !date || !category) {
        errorBox.textContent = 'All fields are required.';
        return;
    }
    errorBox.textContent = '';
    addEvent(name, date, category);
    form.reset();
}

// JS Exercise 11: simulated AJAX/Fetch POST with setTimeout delay
function submitRegistration(eventId) {
    document.getElementById('registerStatus').textContent = 'Submitting...';
    setTimeout(() => {
        const ok = registerUser(eventId);
        const message = ok ? 'Registered!' : 'Could not register (full or invalid event).';
        // JS Exercise 14: jQuery fade transition for the final status, defined in index.html
        if (typeof flashRegisterStatus === 'function') {
            flashRegisterStatus(message);
        } else {
            document.getElementById('registerStatus').textContent = message;
        }
    }, 500);
}

document.addEventListener('DOMContentLoaded', () => {
    renderEvents(events);
    const form = document.getElementById('addEventForm');
    if (form) form.addEventListener('submit', handleEventForm);
    restorePreference();
});

// --- HTML5 module handlers (moved here from inline <script> per JS Exercise 1) ---

// HTML5 Exercise 5: registration confirmation via <output>
function showConfirmation() {
    const name = document.getElementById('name').value;
    document.getElementById('confirmation').textContent =
        'Thanks, ' + name + '! Your registration was received.';
    savePreference();
    return false; // demo only, don't actually navigate away
}

// HTML5 Exercise 6: onblur phone validation
function validatePhone() {
    const phone = document.getElementById('phone').value;
    const valid = /^\d{3}-\d{3}-\d{4}$/.test(phone);
    document.getElementById('phoneError').textContent =
        phone && !valid ? 'Use format 555-123-4567' : '';
}

// HTML5 Exercise 6: onchange event fee display
function showEventFee() {
    const select = document.getElementById('eventType');
    const selected = select.options[select.selectedIndex];
    const fee = selected.dataset.fee;
    document.getElementById('eventFee').textContent =
        fee !== undefined ? `Fee: $${fee}` : '';
}

// HTML5 Exercise 6: ondblclick image enlarge (toggle)
function enlargeImage(img) {
    const enlarged = img.style.height === '320px';
    img.style.height = enlarged ? '' : '320px';
    img.closest('.eventCard').style.gridColumn = enlarged ? '' : 'span 2';
}

// HTML5 Exercise 6: keyup character counter
function countCharacters() {
    const len = document.getElementById('message').value.length;
    document.getElementById('charCount').textContent = `${len} characters`;
}

// HTML5 Exercise 7: oncanplay media event
function videoReady() {
    document.getElementById('videoStatus').textContent = 'Video ready to play';
}

// HTML5 Exercise 7: onbeforeunload warning while form has unsaved input
window.onbeforeunload = function (e) {
    const form = document.getElementById('registrationForm');
    const hasInput = Array.from(form.elements).some(el => el.value);
    if (hasInput) {
        e.preventDefault();
        e.returnValue = '';
    }
};

// HTML5 Exercise 8: localStorage preference save/restore
function savePreference() {
    const eventType = document.getElementById('eventType').value;
    if (eventType) {
        localStorage.setItem('preferredEventType', eventType);
    }
}

function restorePreference() {
    const saved = localStorage.getItem('preferredEventType');
    if (saved) {
        document.getElementById('eventType').value = saved;
        showEventFee();
    }
}

function clearPreferences() {
    localStorage.removeItem('preferredEventType');
    sessionStorage.clear();
    document.getElementById('eventType').value = '';
    document.getElementById('eventFee').textContent = '';
}

// HTML5 Exercise 9: geolocation
function findNearbyEvents() {
    const status = document.getElementById('locationStatus');
    if (!navigator.geolocation) {
        status.textContent = 'Geolocation is not supported by this browser.';
        return;
    }
    navigator.geolocation.getCurrentPosition(
        position => {
            const { latitude, longitude } = position.coords;
            status.textContent = `Your location: ${latitude.toFixed(4)}, ${longitude.toFixed(4)}`;
        },
        error => {
            if (error.code === error.PERMISSION_DENIED) {
                status.textContent = 'Location permission denied.';
            } else if (error.code === error.TIMEOUT) {
                status.textContent = 'Location request timed out.';
            } else {
                status.textContent = 'Unable to retrieve location.';
            }
        },
        { enableHighAccuracy: true, timeout: 10000, maximumAge: 0 }
    );
}
