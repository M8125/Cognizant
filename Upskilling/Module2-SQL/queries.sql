-- Module 2: ANSI SQL Using MySQL - 25 exercises against event_portal schema/seed.
-- Date-relative queries ("last N days") use a fixed reference date instead of
-- CURDATE(), since the seed data is anchored to fixed 2025 dates, not real "today".
USE event_portal;
SET @today = '2025-06-18';

-- 1. User Upcoming Events: events a given user (e.g. user 1) is registered for,
-- in their own city, that are still upcoming, sorted by date.
SELECT DISTINCT e.event_id, e.title, e.city, e.start_date
FROM events e
JOIN registrations r ON r.event_id = e.event_id
JOIN users u ON u.user_id = r.user_id
WHERE u.user_id = 1
  AND e.city = u.city
  AND e.status = 'upcoming'
ORDER BY e.start_date;

-- 2. Top Rated Events (>= 10 feedback submissions only)
SELECT e.event_id, e.title, AVG(f.rating) AS avg_rating, COUNT(*) AS feedback_count
FROM events e
JOIN feedback f ON f.event_id = e.event_id
GROUP BY e.event_id, e.title
HAVING COUNT(*) >= 10
ORDER BY avg_rating DESC;

-- 3. Inactive Users: no registration in the last 90 days (relative to @today)
SELECT u.user_id, u.full_name
FROM users u
WHERE u.user_id NOT IN (
    SELECT r.user_id FROM registrations r
    WHERE r.registration_date >= DATE_SUB(@today, INTERVAL 90 DAY)
);

-- 4. Peak Session Hours: sessions starting between 10 AM-12 PM, per event
SELECT event_id, COUNT(*) AS sessions_10_to_12
FROM sessions
WHERE TIME(start_time) BETWEEN '10:00:00' AND '12:00:00'
GROUP BY event_id;

-- 5. Most Active Cities: top 5 by distinct user registrations
SELECT u.city, COUNT(DISTINCT r.user_id) AS distinct_registered_users
FROM users u
JOIN registrations r ON r.user_id = u.user_id
GROUP BY u.city
ORDER BY distinct_registered_users DESC
LIMIT 5;

-- 6. Event Resource Summary: resource counts per event, by type
SELECT event_id,
       SUM(resource_type = 'pdf')   AS pdf_count,
       SUM(resource_type = 'image') AS image_count,
       SUM(resource_type = 'link')  AS link_count,
       COUNT(*) AS total_resources
FROM resources
GROUP BY event_id;

-- 7. Low Feedback Alerts: rating < 3, with comments + event name
SELECT u.full_name, e.title AS event_name, f.rating, f.comments
FROM feedback f
JOIN users u ON u.user_id = f.user_id
JOIN events e ON e.event_id = f.event_id
WHERE f.rating < 3;

-- 8. Sessions per Upcoming Event
SELECT e.event_id, e.title, COUNT(s.session_id) AS session_count
FROM events e
LEFT JOIN sessions s ON s.event_id = e.event_id
WHERE e.status = 'upcoming'
GROUP BY e.event_id, e.title;

-- 9. Organizer Event Summary
SELECT u.user_id, u.full_name, e.status, COUNT(*) AS event_count
FROM events e
JOIN users u ON u.user_id = e.organizer_id
GROUP BY u.user_id, u.full_name, e.status;

-- 10. Feedback Gap: events with registrations but zero feedback
SELECT DISTINCT e.event_id, e.title
FROM events e
JOIN registrations r ON r.event_id = e.event_id
LEFT JOIN feedback f ON f.event_id = e.event_id
WHERE f.feedback_id IS NULL;

-- 11. Daily New User Count: registrations per day, last 7 days
SELECT registration_date, COUNT(*) AS new_users
FROM users
WHERE registration_date >= DATE_SUB(@today, INTERVAL 7 DAY)
GROUP BY registration_date
ORDER BY registration_date;

-- 12. Event with Maximum Sessions
SELECT event_id, COUNT(*) AS session_count
FROM sessions
GROUP BY event_id
ORDER BY session_count DESC
LIMIT 1;

-- 13. Average Rating per City
SELECT e.city, AVG(f.rating) AS avg_rating
FROM events e
JOIN feedback f ON f.event_id = e.event_id
GROUP BY e.city;

-- 14. Most Registered Events: top 3 by registration count
SELECT e.event_id, e.title, COUNT(r.registration_id) AS registration_count
FROM events e
JOIN registrations r ON r.event_id = e.event_id
GROUP BY e.event_id, e.title
ORDER BY registration_count DESC
LIMIT 3;

-- 15. Event Session Time Conflict: overlapping sessions within the same event
SELECT a.event_id, a.session_id AS session_a, b.session_id AS session_b,
       a.start_time AS a_start, a.end_time AS a_end,
       b.start_time AS b_start, b.end_time AS b_end
FROM sessions a
JOIN sessions b ON a.event_id = b.event_id AND a.session_id < b.session_id
WHERE a.start_time < b.end_time AND b.start_time < a.end_time;

-- 16. Unregistered Active Users: account created in last 30 days, no registrations
SELECT u.user_id, u.full_name
FROM users u
WHERE u.registration_date >= DATE_SUB(@today, INTERVAL 30 DAY)
  AND u.user_id NOT IN (SELECT user_id FROM registrations);

-- 17. Multi-Session Speakers: speakers handling more than one session overall
SELECT speaker_name, COUNT(*) AS session_count
FROM sessions
GROUP BY speaker_name
HAVING COUNT(*) > 1;

-- 18. Resource Availability Check: events with zero resources
SELECT e.event_id, e.title
FROM events e
LEFT JOIN resources res ON res.event_id = e.event_id
WHERE res.resource_id IS NULL;

-- 19. Completed Events with Feedback Summary
SELECT e.event_id, e.title,
       COUNT(DISTINCT r.registration_id) AS total_registrations,
       AVG(f.rating) AS avg_rating
FROM events e
LEFT JOIN registrations r ON r.event_id = e.event_id
LEFT JOIN feedback f ON f.event_id = e.event_id
WHERE e.status = 'completed'
GROUP BY e.event_id, e.title;

-- 20. User Engagement Index: events attended + feedback submitted, per user
SELECT u.user_id, u.full_name,
       COUNT(DISTINCT r.event_id) AS events_attended,
       COUNT(DISTINCT f.feedback_id) AS feedback_submitted
FROM users u
LEFT JOIN registrations r ON r.user_id = u.user_id
LEFT JOIN feedback f ON f.user_id = u.user_id
GROUP BY u.user_id, u.full_name;

-- 21. Top Feedback Providers: top 5 users by feedback count
SELECT u.user_id, u.full_name, COUNT(*) AS feedback_count
FROM feedback f
JOIN users u ON u.user_id = f.user_id
GROUP BY u.user_id, u.full_name
ORDER BY feedback_count DESC
LIMIT 5;

-- 22. Duplicate Registrations Check: same user registered twice for same event
SELECT user_id, event_id, COUNT(*) AS times_registered
FROM registrations
GROUP BY user_id, event_id
HAVING COUNT(*) > 1;

-- 23. Registration Trends: month-wise count, past 12 months
SELECT DATE_FORMAT(registration_date, '%Y-%m') AS month, COUNT(*) AS registrations
FROM registrations
WHERE registration_date >= DATE_SUB(@today, INTERVAL 12 MONTH)
GROUP BY month
ORDER BY month;

-- 24. Average Session Duration per Event (minutes)
SELECT event_id, AVG(TIMESTAMPDIFF(MINUTE, start_time, end_time)) AS avg_duration_minutes
FROM sessions
GROUP BY event_id;

-- 25. Events Without Sessions
SELECT e.event_id, e.title
FROM events e
LEFT JOIN sessions s ON s.event_id = e.event_id
WHERE s.session_id IS NULL;
