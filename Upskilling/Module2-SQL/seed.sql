-- Seed data: PDF's sample dataset (rows 1-5/1-3/1-4 etc.) plus extra rows so that
-- queries like "top rated with >= 10 feedback" or "top 5 cities" have enough data
-- to actually exercise the logic instead of trivially returning everything/nothing.
USE event_portal;

INSERT INTO users (user_id, full_name, email, city, registration_date) VALUES
(1, 'Alice Johnson', 'alice@example.com', 'New York', '2024-12-01'),
(2, 'Bob Smith', 'bob@example.com', 'Los Angeles', '2024-12-05'),
(3, 'Charlie Lee', 'charlie@example.com', 'Chicago', '2024-12-10'),
(4, 'Diana King', 'diana@example.com', 'New York', '2025-01-15'),
(5, 'Ethan Hunt', 'ethan@example.com', 'Los Angeles', '2025-02-01'),
(6, 'Fiona Apple', 'fiona@example.com', 'New York', '2025-05-20'),
(7, 'George Park', 'george@example.com', 'Chicago', '2025-05-25'),
(8, 'Hannah Wells', 'hannah@example.com', 'Los Angeles', '2025-06-01'),
(9, 'Ivan Petrov', 'ivan@example.com', 'New York', '2025-06-05'),
(10, 'Julia Roe', 'julia@example.com', 'Chicago', '2025-06-10');

INSERT INTO events (event_id, title, description, city, start_date, end_date, status, organizer_id) VALUES
(1, 'Tech Innovators Meetup', 'A meetup for tech enthusiasts.', 'New York', '2025-06-10 10:00:00', '2025-06-10 16:00:00', 'upcoming', 1),
(2, 'AI & ML Conference', 'Conference on AI and ML advancements.', 'Chicago', '2025-05-15 09:00:00', '2025-05-15 17:00:00', 'completed', 3),
(3, 'Frontend Development Bootcamp', 'Hands-on training on frontend tech.', 'Los Angeles', '2025-07-01 10:00:00', '2025-07-03 16:00:00', 'upcoming', 2),
(4, 'Cloud Native Summit', 'Talks on Kubernetes and serverless.', 'Chicago', '2025-04-01 09:00:00', '2025-04-01 18:00:00', 'completed', 3),
(5, 'Community Art Fair', 'Local artists showcase.', 'New York', '2025-03-01 10:00:00', '2025-03-01 15:00:00', 'cancelled', 1);

INSERT INTO sessions (session_id, event_id, title, speaker_name, start_time, end_time) VALUES
(1, 1, 'Opening Keynote', 'Dr. Tech', '2025-06-10 10:00:00', '2025-06-10 11:00:00'),
(2, 1, 'Future of Web Dev', 'Alice Johnson', '2025-06-10 11:15:00', '2025-06-10 12:30:00'),
(3, 2, 'AI in Healthcare', 'Charlie Lee', '2025-05-15 09:30:00', '2025-05-15 11:00:00'),
(4, 3, 'Intro to HTML5', 'Bob Smith', '2025-07-01 10:00:00', '2025-07-01 12:00:00'),
(5, 4, 'Kubernetes 101', 'Charlie Lee', '2025-04-01 09:30:00', '2025-04-01 11:00:00'),
(6, 4, 'Serverless Patterns', 'Charlie Lee', '2025-04-01 10:30:00', '2025-04-01 12:00:00');
-- sessions 5 and 6 overlap on purpose (Exercise 15: time-conflict detection)

INSERT INTO registrations (registration_id, user_id, event_id, registration_date) VALUES
(1, 1, 1, '2025-05-01'),
(2, 2, 1, '2025-05-02'),
(3, 3, 2, '2025-04-30'),
(4, 4, 2, '2025-04-28'),
(5, 5, 3, '2025-06-15'),
(6, 6, 2, '2025-04-29'),
(7, 7, 4, '2025-03-25'),
(8, 8, 4, '2025-03-26'),
(9, 9, 1, '2025-06-01'),
(10, 1, 1, '2025-06-02');
-- registration 10 duplicates user 1 + event 1 on purpose (Exercise 22: duplicate check)

INSERT INTO feedback (feedback_id, user_id, event_id, rating, comments, feedback_date) VALUES
(1, 3, 2, 4, 'Great insights!', '2025-05-16'),
(2, 4, 2, 5, 'Very informative.', '2025-05-16'),
(3, 2, 1, 3, 'Could be better.', '2025-06-11'),
(4, 6, 2, 5, 'Loved the AI talks.', '2025-05-17'),
(5, 7, 4, 2, 'Audio issues throughout.', '2025-04-02'),
(6, 8, 4, 1, 'Too crowded.', '2025-04-02');
-- event 3 (upcoming) and event 5 (cancelled) intentionally have 0 feedback rows
-- (Exercise 10: feedback gap)

INSERT INTO resources (resource_id, event_id, resource_type, resource_url, uploaded_at) VALUES
(1, 1, 'pdf', 'https://portal.com/resources/tech_meetup_agenda.pdf', '2025-05-01 10:00:00'),
(2, 2, 'image', 'https://portal.com/resources/ai_poster.jpg', '2025-04-20 09:00:00'),
(3, 3, 'link', 'https://portal.com/resources/html5_docs', '2025-06-25 15:00:00');
-- events 4 and 5 intentionally have 0 resources (Exercise 18: resource availability)
