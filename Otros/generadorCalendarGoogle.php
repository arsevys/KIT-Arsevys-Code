<?php

function getGCalendarUrl($event)
{
    $titulo       = urlencode($event['titulo']);
    $descripcion  = urlencode($event['descripcion']); 
    $localizacion = urlencode($event['localizacion']);
    $start        = new DateTime($event['fecha_inicio'] . ' ' . $event['hora_inicio']);

    $end     = new DateTime($event['fecha_fin'] . ' ' . $event['hora_fin'] . ' ' . date_default_timezone_get());
    $dates   = urlencode($start->format("Ymd")) . "T" . urlencode($start->format("His")) . "/" . urlencode($end->format("Ymd")) . "T" . urlencode($end->format("His"));
    $name    = urlencode($event['nombre']);

    $url     = urlencode($event['url']);
    $gCalUrl = "https://calendar.google.com/calendar/r/eventedit?text=$titulo&dates=$dates&details=$descripcion&location=$localizacion&trp=false&sprop=$url&sprop=name:$name&sf=true&output=xml";
    return ($gCalUrl);
}

$evento = array(
    'titulo'       => 'Asistentes Virtuales MDP',
    'descripcion'  => 'Descripcion De Chatbots',
    'localizacion' => 'Restaurante La carreta',
    'fecha_inicio' => '2018-04-10', // Fecha de inicio de evento en formato AAAA-MM-DD
    'hora_inicio'  => '17:30', // Hora Inicio del evento
    'fecha_fin'    => '2018-04-12', // Fecha de fin de evento en formato AAAA-MM-DD
    'hora_fin'     => '19:00', // Hora final del evento
    'nombre'       => 'Arsevys', // Nombre del sitio
    'url'          => 'www.mdp.com.pe', // Url de la página
);

echo getGCalendarUrl($evento);
