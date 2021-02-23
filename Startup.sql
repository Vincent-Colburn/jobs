use jobsrus;

-- CREATE TABLE contractors 
-- (
--     id INT AUTO_INCREMENT, 
--     name VARCHAR(255) NOT NULL,
--     role VARCHAR(255) NOT NULL, 

--     PRIMARY KEY (id)
-- );


-- CREATE TABLE jobs
-- (
--     id INT AUTO_INCREMENT, 
--     jobname VARCHAR(255),

--     PRIMARY KEY (id)
-- );

-- CREATE TABLE personnel
-- (
--     id INT AUTO_INCREMENT,
--     jobId INT, 
--     contractorId INT,

--     PRIMARY KEY (id),

--     FOREIGN KEY (jobId)
--         REFERENCES jobs(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (contractorId)
--         REFERENCES contractors(id)
--         ON DELETE CASCADE
-- );