
DROP PROCEDURE IF EXISTS `Member_AgeGender`;

DELIMITER $$
CREATE DEFINER=`hcsyria`@`%` PROCEDURE `Member_AgeGender`(IN `VisitName` VARCHAR(100), IN `Donor_ID` INT(11), IN `Partner_ID` INT(11), IN `IsSolar` INT(11), IN `SolarDonor_ID` INT(11), IN `IsRenovation` INT(11), IN `RenovationDonor_ID` INT(11), IN `Distriburion_ID` INT(11))
BEGIN
SET SESSION group_concat_max_len = 1000000;
SET @sql1 = null;
SET @sql2 = null;
SET @sql3 = null;
SET @sql4 = null;
SET @where1 = null;
SET @group1 = null;
SET @order1 = null;

SELECT GROUP_CONCAT(DISTINCT 
CONCAT('(SELECT COUNT(person.id) \r\n       FROM person LEFT JOIN person_family ON person.id = person_family.person_id\r\n       LEFT JOIN person_state ON person_state.person_id = person.id \r\n       LEFT JOIN personstate ON person_state.personstate_id = personstate.id \r\n       LEFT JOIN sex ON sex.id = person.sex_id \r\n       WHERE person_family.family_id = family.id \r\n       AND person_state.family_id = family.id\r\n       AND person_state.current_state = ''1'' \r\n       AND LOWER(personstate.type) = LOWER(''Active'') \r\n       AND sex.name = ''ذكر'' \r\n AND (CASE WHEN YEAR(CURDATE()) - YEAR(person.DOB) = 0 THEN 1 ELSE YEAR(CURDATE()) - YEAR(person.DOB) END) BETWEEN ',agerange.min_age,' AND ',agerange.max_age,') AS `عدد الذكور المستفيدين ',agerange.name,'`, ','(SELECT COUNT(person.id) \r\n       FROM person LEFT JOIN person_family ON person.id = person_family.person_id\r\n       LEFT JOIN person_state ON person_state.person_id = person.id \r\n       LEFT JOIN personstate ON person_state.personstate_id = personstate.id \r\n       LEFT JOIN sex ON sex.id = person.sex_id \r\n       WHERE person_family.family_id = family.id \r\n       AND person_state.family_id = family.id\r\n       AND person_state.current_state = ''1'' \r\n       AND LOWER(personstate.type) = LOWER(''Active'') \r\n       AND sex.name = ''أنثى'' \r\n AND (CASE WHEN YEAR(CURDATE()) - YEAR(person.DOB) = 0 THEN 1 ELSE YEAR(CURDATE()) - YEAR(person.DOB) END) BETWEEN ',agerange.min_age,' AND ',agerange.max_age,') AS `عدد الاناث المستفيدات ',agerange.name,'`' 
 
)ORDER BY agerange.id) 
INTO @sql1
FROM agerange
WHERE agerange.name <> 'N/A';



SELECT GROUP_CONCAT(DISTINCT 
CONCAT('(SELECT COUNT(person.id) \r\n       FROM person LEFT JOIN person_family ON person.id = person_family.person_id\r\n       LEFT JOIN person_state ON person_state.person_id = person.id \r\n       LEFT JOIN personstate ON person_state.personstate_id = personstate.id \r\n       LEFT JOIN sex ON sex.id = person.sex_id \r\n       WHERE person_family.family_id = family.id \r\n       AND person_state.family_id = family.id\r\n       AND person_state.current_state = ''1'' \r\n       AND LOWER(personstate.type) = LOWER(''Disactive'') \r\n       AND sex.name = ''ذكر'' \r\n AND (CASE WHEN YEAR(CURDATE()) - YEAR(person.DOB) = 0 THEN 1 ELSE YEAR(CURDATE()) - YEAR(person.DOB) END) BETWEEN ',agerange.min_age,' AND ',agerange.max_age,') AS `عدد الذكور غير المستفيدين ',agerange.name,'`, ','(SELECT COUNT(person.id) \r\n       FROM person LEFT JOIN person_family ON person.id = person_family.person_id\r\n       LEFT JOIN person_state ON person_state.person_id = person.id \r\n       LEFT JOIN personstate ON person_state.personstate_id = personstate.id \r\n       LEFT JOIN sex ON sex.id = person.sex_id \r\n       WHERE person_family.family_id = family.id \r\n       AND person_state.family_id = family.id\r\n       AND person_state.current_state = ''1'' \r\n       AND LOWER(personstate.type) = LOWER(''Disactive'') \r\n       AND sex.name = ''أنثى'' \r\n AND (CASE WHEN YEAR(CURDATE()) - YEAR(person.DOB) = 0 THEN 1 ELSE YEAR(CURDATE()) - YEAR(person.DOB) END) BETWEEN ',agerange.min_age,' AND ',agerange.max_age,') AS `عدد الاناث غير المستفيدات ',agerange.name,'`' 
 
)ORDER BY agerange.id) 
INTO @sql2
FROM agerange
WHERE agerange.name <> 'N/A';



SET @sql3 = CONCAT('SELECT family.id AS `Family_id`,\r\n       family.code AS `رمز العائلة`,\r\n       donor.id AS `Donor_id`,\r\n       donor.name AS `الممول`,\r\n       partner.id as `Partner_id`,\r\n       partner.name as `الشريك`,\r\n       (CASE family_partner.IsActive WHEN 1 THEN ''فعالة'' ELSE ''غير فعالة'' END) AS `الحالة`,\r\n       (CASE family.LivingWithFamily WHEN 1 THEN ''نعم'' ELSE ''لا'' END) AS `هل تسكن مع عائلة أخرى`,\r\n\t\tGROUP_CONCAT((CASE \r\n            WHEN family_livingwith.family_id1 <> family.id THEN LivWithFamily1.code \r\n            WHEN family_livingwith.family_id2 <> family.id THEN LivWithFamily2.code  \r\n        END)) AS `تسكن مع`,\r\n        GROUP_CONCAT(family_livingwith.note) AS `ملاحظات السكن مع عائلة أخرى`,\r\n        \r\n        family_visit.visit_name AS ''الزيارة'',\r\n        (CASE family_visitdetails.expenses_17_home WHEN 1 THEN ''نعم'' ELSE ''لا'' END) AS `هل يوجد طاقة شمسية؟`,\r\n        SolarAid.id AS `SolarAid_id`,\r\n        SolarAid.name AS `جهة المساعدة - الطاقة الشمسية`,\r\n        \r\n        (CASE WHEN family_visitdetails.aid_17_home > 0 THEN ''نعم'' ELSE ''لا'' END) AS `هل يوجد مساعدة ترميم؟`,        \r\n        RenovationAid.id AS `RenovationAid_id`,\r\n        RenovationAid.name AS `الجهة الداعمة - ترميم`,\r\n                \r\n(SELECT COUNT(person_family.id) FROM person_family WHERE person_family.family_id = family.id ) as `عدد أفراد الأسرة`,\r\n\r\n(SELECT COUNT(person.id) \r\n                        FROM person\r\n \t\t\t\tLEFT JOIN person_family ON person.id = person_family.person_id\r\n                        LEFT JOIN person_state on person_state.person_id = person.id \r\n                        LEFT JOIN personstate on person_state.personstate_id = personstate.id\r\n                        WHERE person_family.family_id = family.id \r\n                        and person_state.current_state = ''1'' \r\n                        and LOWER(personstate.type) = LOWER(''Active'') \r\n                        and person_state.family_id = family.id) as `عدد المستفيدين`,\r\n                        \r\n(SELECT COUNT(person.id) \r\n                        FROM person\r\n \t\t\t\t\t\tLEFT JOIN person_family ON person.id = person_family.person_id\r\n                        LEFT JOIN person_state on person_state.person_id = person.id \r\n                        LEFT JOIN personstate on person_state.personstate_id = personstate.id\r\n \t\t\t\t\t\tLEFT JOIN sex ON sex.id = person.sex_id\r\n                        WHERE person_family.family_id = family.id \r\n                        and person_state.current_state = ''1'' \r\n                        and LOWER(personstate.type) = LOWER(''Active'') \r\n \t\t\t\t\t\tAND sex.name = ''ذكر''\r\n                        and person_state.family_id = family.id) as `عدد الذكور المستفيدين`,\r\n                        \r\n                                                \r\n(SELECT COUNT(person.id) \r\n                        FROM person\r\n \t\t\t\tLEFT JOIN person_family ON person.id = person_family.person_id\r\n                        LEFT JOIN person_state on person_state.person_id = person.id \r\n                        LEFT JOIN personstate on person_state.personstate_id = personstate.id\r\n \t\t\t\tLEFT JOIN sex ON sex.id = person.sex_id\r\n                        WHERE person_family.family_id = family.id \r\n                        and person_state.current_state = ''1'' \r\n                        and LOWER(personstate.type) = LOWER(''Active'') \r\n \t\t\t\tAND sex.name = ''أنثى''\r\n                        and person_state.family_id = family.id) as `عدد الاناث المستفيدات`, ',@sql1,' ,(SELECT COUNT(person.id) \r\n                        FROM person\r\n \t\t\t\tLEFT JOIN person_family ON person.id = person_family.person_id\r\n                        LEFT JOIN person_state on person_state.person_id = person.id \r\n                        LEFT JOIN personstate on person_state.personstate_id = personstate.id\r\n                        WHERE person_family.family_id = family.id \r\n                        and person_state.current_state = ''1'' \r\n                        and LOWER(personstate.type) = LOWER(''Disactive'') \r\n                        and person_state.family_id = family.id) as `عدد غير المستفيدين`,\r\n                        \r\n(SELECT COUNT(person.id) \r\n                        FROM person\r\n \t\t\t\tLEFT JOIN person_family ON person.id = person_family.person_id\r\n                        LEFT JOIN person_state on person_state.person_id = person.id \r\n                        LEFT JOIN personstate on person_state.personstate_id = personstate.id\r\n \t\t\t\tLEFT JOIN sex ON sex.id = person.sex_id\r\n                        WHERE person_family.family_id = family.id \r\n                        and person_state.current_state = ''1'' \r\n                        and LOWER(personstate.type) = LOWER(''Disactive'') \r\n \t\t\t\tAND sex.name = ''ذكر''\r\n                        and person_state.family_id = family.id) as `عدد الذكور غير المستفيدين`,\r\n                        \r\n                                                \r\n(SELECT COUNT(person.id) \r\n                        FROM person\r\n \t\t\t\tLEFT JOIN person_family ON person.id = person_family.person_id\r\n                        LEFT JOIN person_state on person_state.person_id = person.id \r\n                        LEFT JOIN personstate on person_state.personstate_id = personstate.id\r\n \t\t\t\tLEFT JOIN sex ON sex.id = person.sex_id\r\n                        WHERE person_family.family_id = family.id \r\n                        and person_state.current_state = ''1'' \r\n                        and LOWER(personstate.type) = LOWER(''Disactive'') \r\n \t\t\t\tAND sex.name = ''أنثى''\r\n                        and person_state.family_id = family.id) as `عدد الاناث غير المستفيدات`, ',@sql2);

IF (Distriburion_ID > 0) THEN 
SET @sql3 = concat(@sql3, ',(SELECT signature_list.RecievedMoney FROM signature_list LEFT JOIN partner_distribution ON partner_distribution.id = signature_list.partner_distribution_id LEFT JOIN distribution ON distribution.id = partner_distribution.distribution_id where signature_list.family_id = family.id and distribution.id = ',Distriburion_ID,') AS ''استلمت المبلغ''');
End If;

SET @sql3 = concat(@sql3,' FROM family\r\nLEFT JOIN family_partner ON family.id = family_partner.family_id\r\nLEFT JOIN partner_donor ON partner_donor.id = family_partner.partner_donor_id\r\nLEFT JOIN partner ON partner.id = partner_donor.partner_id\r\nLEFT JOIN donor ON donor.id = partner_donor.donor_id\r\nLEFT JOIN family_livingwith on family.id in (family_livingwith.family_id1, family_livingwith.family_id2)\r\nLEFT JOIN family LivWithFamily1 on LivWithFamily1.id = family_livingwith.family_id1\r\nLEFT JOIN family LivWithFamily2 on LivWithFamily2.id = family_livingwith.family_id2\r\nLEFT JOIN family_visit ON family_visit.family_id = family.id\r\nLEFT JOIN family_visitdetails ON family_visitdetails.family_visit_id = family_visit.id\r\nLEFT JOIN aidsource SolarAid on SolarAid.id = family_visitdetails.aidsource_16\r\nLEFT JOIN aidsource RenovationAid on RenovationAid.id = family_visitdetails.aidsource_17_home\r\n\r\n');


SET @where1 = ' where 1 '; 
 IF (VisitName <> 'N/A' AND VisitName <> ''AND VisitName <> ' ') THEN 
 	SET @where1 = concat(@where1,' and family_visit.visit_name = ''',VisitName,'''');
 End If;
IF (Donor_ID > 0) THEN 
 	SET @where1 = concat(@where1,' and donor.id = ',Donor_ID);
 End If;
 IF (Partner_ID > 0) THEN 
 	SET @where1 = concat(@where1,' and partner.id = ',Partner_ID);
 End If;
 IF (IsSolar >= 0) THEN 
 	SET @where1 = concat(@where1,' and family_visitdetails.expenses_17_home = ',IsSolar);
 End If;
IF (SolarDonor_ID > 0) THEN 
 	SET @where1 = concat(@where1,' and SolarAid.id = ',SolarDonor_ID);
 End If;
  IF (IsRenovation >= 0) THEN 
 	SET @where1 = concat(@where1,' and family_visitdetails.aid_17_home = ',IsRenovation);
 End If;
 IF (RenovationDonor_ID > 0) THEN 
 	SET @where1 = concat(@where1,' and RenovationAid.id = ',RenovationDonor_ID);
 End If;
 IF (Distriburion_ID > 0) THEN 
	SET @where1 = concat(@where1, ' AND family.id in (SELECT signature_list.family_id FROM signature_list LEFT JOIN partner_distribution ON partner_distribution.id = signature_list.partner_distribution_id LEFT JOIN distribution ON distribution.id = partner_distribution.distribution_id where distribution.id = ',Distriburion_ID,')');
 End If;
 
 SET @group1 = ' GROUP BY family_visit.visit_name, donor.id, partner.id, family.id ';
 
 SET @order1 = ' ORDER BY family.code ';

 SET @sql4 = CONCAT(@sql3,@where1,@group1);
 

 
PREPARE stmt FROM @sql4;
EXECUTE stmt;

-- SELECT @sql4;

SET @sql1 = null;
SET @sql2 = null;
SET @sql3 = null;
SET @sql4 = null;
SET @where1 = null;
SET @group1 = null;
SET @order1 = null;


END$$
DELIMITER ;