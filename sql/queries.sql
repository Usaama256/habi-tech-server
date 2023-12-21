-- Get a particular user
SELECT user_id, username, profile_picture, email, pass FROM user WHERE user_id=1;

SELECT type_id, type_name, type_description FROM device_type;

-- All user's devices
SELECT device_id, device_name, device_description, type_name, user_id, FROM device JOIN device_type USING(type_id) WHERE user_id=1;

--- Lights ---

-- All user's lights 
SELECT device_id, device_name, device_description, type_name, user_id, status FROM device JOIN device_type USING(type_id) WHERE user_id=2 and type_id=2;

-- Switch on a light 
UPDATE device SET status='ON' WHERE device_id=3 and type_id=2 and user_id=1;

-- Switch off a ight 
UPDATE device SET status='OFF' WHERE device_id=3 and type_id=2 and user_id=1;


-- Switch on all light 
UPDATE device SET status='ON' WHERE type_id=2 and user_id=1;

-- Switch on all light 
UPDATE device SET status='OFF' WHERE type_id=2 and user_id=1;
--- Lights ---