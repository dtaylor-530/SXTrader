<?php
/*
 * Created on 02.08.2011
 *
 * To change the template for this generated file go to
 * Window - Preferences - PHPeclipse - PHP - Code Templates
 */
 
   include 'LSDatabase.php';
   
   $teamId = isset($_GET["teamId"]) ? $_GET["teamId"]+0 : 0;
   $teamName = $_GET["teamName"];
   
   $statisticDb = new LSDatabase();
   $statisticDb->insertTeamName($teamId, $teamName);
?>
