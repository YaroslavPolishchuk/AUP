/*Procedure*/
CREATE PROCEDURE UPLOAD_AUP () LANGUAGE PLPGSQL AS $$
BEGIN

IF EXISTS (SELECT 1 FROM AUP) THEN
        RETURN;
    END IF;

    CREATE TEMPORARY TABLE TEMP_UPOST (
        REG VARCHAR(200),
        DIST VARCHAR(200),
        SETT VARCHAR(200),
        POSTCODE VARCHAR(200)
    );

    COPY TEMP_UPOST (REG, DIST, SETT, POSTCODE)
    FROM '/tmp/upostdata.csv' DELIMITER ';';

    INSERT INTO AUP (POSTCODE, CITY, NCITY, NOBL, OBL, NRAJ, RAJ)
    SELECT * FROM (
        WITH BASE AS (
            SELECT DISTINCT
                CI.CITY_KOD,
                CI.NCITY,
                R.NRAJ,
                R.RAJ,
                O.OBL,
                O.NOBL
            FROM
                CITY CI
                JOIN RAJ R ON R.RAJ = CI.KRAJ
                JOIN OBL O ON O.OBL = CI.KOBL
        )
        SELECT DISTINCT
            ON (IND.POSTCODE) IND.POSTCODE::INT,
            CASE
                WHEN IND.SETT = T1.NCITY THEN T1.CITY_KOD
                ELSE NULL
            END AS CITY_KOD,
            CASE
                WHEN IND.SETT = T1.NCITY THEN T1.NCITY
                ELSE NULL
            END AS NCITY,
            CASE
                WHEN IND.REG = T1.NOBL THEN T1.NOBL
                ELSE NULL
            END AS NOBL,
            CASE
                WHEN IND.REG = T1.NOBL THEN T1.OBL
                ELSE NULL
            END AS OBL,
            CASE
                WHEN IND.DIST = T1.NRAJ THEN T1.NRAJ
                ELSE NULL
            END AS NRAJ,
            CASE
                WHEN IND.DIST = T1.NRAJ THEN T1.RAJ
                ELSE NULL
            END AS RAJ
        FROM
            TEMP_UPOST IND
            LEFT JOIN BASE T1 ON IND.REG = T1.NOBL
            OR IND.DIST = T1.NRAJ
            OR IND.SETT = T1.NCITY
    ) ORDER BY NCITY;		
END;
$$;


/*-------*/