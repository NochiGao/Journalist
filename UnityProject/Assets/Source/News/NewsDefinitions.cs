public static class NewsDefinitions
{
    private static News[] definedNews =
    {
        //	Titular	,	Cuerpo	,	Min Op	,	Max Op	,	Min Of	,	Max Of	,	Min Conv	,	Max Conv	
new News( 	"Gloriosa Revolución"	,	"El General Albatros toma la presidencia y libera a la nación del oloroso Presidente Palometa. Algarabía en las calles."	,	-0.2	,	-0.1	,	0.1	,	0.2	,	0	,	0	),
new News( 	"Sangrientos enfrentamientos"	,	"Los enfrentamientos liderados por el impostor Albatros ensangrentan la ciudad. Pesimismo en las calles."	,	0.1	,	0.2	,	-0.2	,	-0.1	,	0	,	0	),
new News( 	"Romance confirmado"	,	"Se vio volando juntos a Paloma Herrera y el Pájaro Caniggia. Todo es hermoso."	,	0.01	,	0.03	,	0.01	,	0.03	,	0	,	0	),
new News( 	"Paro de gallos madrugadores"	,	"El pueblo llega tarde a sus trabajos mientras los gallos reclaman aumento."	,	0.02	,	0.04	,	-0.03	,	-0.02	,	-0.03	,	-0.01	),
new News( 	"Huelga de pelícanos"	,	"Escasean los peces, el pueblo debe recurrir a alimentarse solamente de semillas."	,	0.01	,	0.03	,	-0.03	,	-0.01	,	-0.02	,	-0.01	),
new News( 	"Retraso de cigüeñas"	,	"El crecimiento poblacional decae, cae el precio del metro cuadrado de nido."	,	0.01	,	0.03	,	-0.03	,	-0.01	,	-0.02	,	-0.01	),
new News( 	"Pajaronia sede"	,	"La ciudad capital será la anfitriona de los Juegos Aviolímpicos. Grandes expectativas de turismo."	,	0.01	,	0.02	,	0.01	,	0.05	,	0.01	,	0.03	),
new News( 	"Halcones semifinalistas"	,	"El equipo de los halcones llega a la final del mundial de garraball."	,	0.02	,	0.04	,	0.02	,	0.04	,	0	,	0	),
new News( 	"Migraciones de golondrinas"	,	"Las golondrinas, acorraladas por la segregación, deciden emigar, como todos los años."	,	0	,	0.01	,	0	,	0.01	,	0	,	0.01	),
new News( 	"Caranchotti en problemas"	,	"Jefe de Gabinete encontrado en el VIP de un boliche con 500 g de birdnip y un huevo menor de edad."	,	0.05	,	0.1	,	-0.1	,	-0.05	,	-0.03	,	-0.01	),
new News( 	"Renuncian a Caranchotti"	,	"Tras haber sido encontrado con estupefacientes y menores ilegales, Jefe de Gabinete renuncia en medio de un escándalo."	,	0.01	,	0.04	,	0.01	,	0.04	,	-0.05	,	0.05	),
new News( 	"Caranchotti pide disculpas"	,	"Caranchotti pide disculpas y dice, quien no se comió un huevo crudo alguna vez?"	,	-0.06	,	-0.03	,	0.01	,	0.02	,	-0.02	,	-0.01	),
new News( 	"Plaza Central galardonada"	,	"La Plaza Central de Pajaronia ha sido galardonada como la más limpia de Pajaroamérica, con tan sólo un busto manchado de blanco."	,	0	,	0.01	,	0	,	0.01	,	0	,	0.01	),
new News( 	"Golpe al Sindicalismo"	,	"El gobierno recortó aportes al sindicato de pajaros carpinteros. Amenazas de termitas."	,	-0.01	,	0.01	,	0.01	,	0.04	,	-0.05	,	0.05	),
new News( 	"Se reúne Bandada"	,	"Tras 10 años desde su último recital, 3 de los 5 integrantes de Bandada vuelven al escenario con sus hits clásicos."	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	),
new News( 	"Estreno de Perdices Salvajes"	,	"Se estrena la nueva pelicula del aclamado director Damián Pajarón. Alta expectativa de la crítica."	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	),
new News( 	"Por romper el cascarón"	,	"La hija del General Albatros está a punto de romper el cascarón. Será feriado nacional."	,	-0.03	,	-0.01	,	0.02	,	0.03	,	-0.01	,	0.01	),
new News( 	"Se aprueban nuevas leyes proteccionistas"	,	"El gobierno aprueba nuevas leyes proteccionistas. Desazón de los importadores de nidos premium."	,	-0.01	,	0	,	0.01	,	0.04	,	-0.02	,	0.02	),
new News( 	"Conflicto de divas"	,	"La Garza Giménes fustigó a la Urraca Casandra. Tensión en la farándula."	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	),
new News( 	"Robo y muerte en San Aguilar"	,	"La localidad bonvientense trastornada tras un violento robo a mano armada que acabó en tragedia."	,	0.02	,	0.05	,	0.01	,	0.02	,	-0.03	,	0.01	),
new News( 	"Ansiedad"	,	"Faltan 254 días para la época migratoria estival."	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	),
new News( 	"Ganan los Carroñeros"	,	"Tras un intenso enfrentamiento, los Carroñeros vencen a los Palomos Mensajeros por 10 a 1."	,	0.01	,	0.02	,	0.01	,	0.02	,	0	,	0	),
new News( 	"Desfile de moda"	,	"Desfile de alta pluma en Punta Cogotes. Nueva colección causa expectativa." 	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	),
new News( 	"Manifestación de horneros"	,	"Horneros se manifestarán mañana frente al Congreso Avícola antes el alza de impuestos para materiales de construcción."	,	0.02	,	0.04	,	-0.02	,	-0.01	,	-0.02	,	-0.01	),
new News( 	"Represión en manifestación"	,	"Último momento. Dura represión en manifestación de horneros. Varios heridos."	,	0.02	,	0.04	,	-0.02	,	-0.01	,	-0.02	,	-0.01	),
new News( 	"Murió manifestante"	,	"Roberto Picchotti, hornero constructor, murió en la dura represión del régimen de Albatros."	,	0.03	,	0.06	,	-0.03	,	-0.02	,	-0.04	,	-0.02	),
new News( 	"Murió violento vándalo"	,	"Roberto Picchotti, hornero agitador, murió asaltando el Congreso de la Nación."	,	-0.06	,	-0.03	,	0.02	,	0.03	,	0.02	,	0.04	),
new News( 	"Palomos destruyen estadio"	,	"Tras la aplastante derrota de los Palomos Mensajeros, los hinchas enfurecidos destruyen el estadio de Los Carroñeros."	,	0	,	0.01	,	0	,	0.01	,	0	,	0	),

    };

    public static News[] GetNewsDatabase()
    {
        if (definedNews != null)
        {
            return definedNews;
        }

        return new News[0];
    }
}
