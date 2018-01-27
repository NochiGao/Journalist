public static class NewsDefinitions
{
    private static News[] definedNews =
    {
        //	Titular	,	Cuerpo	,	Min Op	,	Max Op	,	Min Of	,	Max Of	,	Min Conv	,	Max Conv	
new News( 	"Gloriosa Revolución"	,	"El General Albatros toma la presidencia y libera a la nación del oloroso Presidente Palometa. Algarabía en las calles."	,	0	,	0	,	0	,	0	,	0	,	0	),
new News( 	"Sangrientos enfrentamientos"	,	"Los enfrentamientos liderados por el impostor Albatros ensangrentan la ciudad. Pesimismo en las calles."	,	0	,	0	,	0	,	0	,	0	,	0	),
new News( 	"Romance confirmado"	,	"Se vio volando juntos a Paloma Herrera y el Pájaro Caniggia. Todo es hermoso."	,	0	,	0	,	0	,	0	,	0	,	0	),
new News( 	"Paro de gallos madrugadores"	,	"El pueblo llega tarde a sus trabajos mientras los gallos reclaman aumento."	,	0.02	,	0.04	,	-0.03	,	-0.02	,	-0.03	,	-0.01	),
new News( 	"Huelga de pelícanos"	,	"Escasean los peces, el pueblo debe recurrir a alimentarse solamente de semillas."	,	0.01	,	0.03	,	-0.03	,	-0.01	,	-0.02	,	-0.01	),
new News( 	"Retraso de cigüeñas"	,	"El crecimiento poblacional decae, cae el precio del metro cuadrado de nido."	,	0.01	,	0.03	,	-0.03	,	-0.01	,	-0.02	,	-0.01	),
new News( 	"Pajaronia sede"	,	"La ciudad capital será la anfitriona de los Juegos Aviolimpicos. Grandes expectativas de turismo."	,	0.01	,	0.02	,	0.01	,	0.05	,	0.01	,	0.03	),
new News( 	"Halcones semifinalistas"	,	"El equipo de los halcones llega a la final del mundial de garraball."	,	0.02	,	0.04	,	0.02	,	0.04	,	0	,	0	),
new News( 	"Migraciones de golondrinas"	,	"Las golondrinas, acorraladas por la segregación, deciden emigar, como todos los años."	,	0	,	0	,	0	,	0	,	0	,	0	),
new News( 	"Caranchotti en problemas"	,	"Jefe de Gabinete encontrado en el VIP de un boliche con 500 g de birdnip y un huevo menor de edad."	,	0	,	0	,	0	,	0	,	0	,	0	),
new News( 	"Renuncian a Caranchotti"	,	"Tras haber sido encontrado con estupefacientes y menores ilegales, Jefe de Gabinete renuncia en medio de un escándalo."	,	0	,	0	,	0	,	0	,	0	,	0	),
new News( 	"Caranchotti pide disculpas"	,	"Caranchotti pide disculpas y dice, quien no se comió un huevo crudo alguna vez?"	,	-0.06	,	-0.03	,	0.01	,	0.02	,	-0.02	,	-0.01	),
new News( 	"Plaza Central galardonada"	,	"La Plaza Central de Pajaronia ha sido galardonada como la más limpia de Pajaroamérica, con tan sólo un busto manchado de blanco."	,	0	,	0.01	,	0	,	0.01	,	0	,	0.01	),

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
