using System.Collections.Generic;

public static class NewsDefinitions
{
    private static News[] definedNews =
    {
//	ID	,	Titular	,	Cuerpo	,	Photo	,	Min Op	,	Max Op	,	Min Of	,	Max Of	,	Min Conv	,	Max Conv	,	RequiredDay	,	RequiredIDs	,	ExcludedIDs		
//	ID	,	Titular	,	Cuerpo	,	Photo	,	Min Op	,	Max Op	,	Min Of	,	Max Of	,	Min Conv	,	Max Conv	,	RequiredDay	,	RequiredIDs	,	ExcludedIDs		
new News( 	1	,	"Gloriosa Revolución"	,	"El General Albatros toma la presidencia y libera a la nación del oloroso Presidente Palometa. Algarabía en las calles."	,	""	,	-0.1	,	-0.05	,	0.05	,	0.1	,	0	,	0	,	1	, new List<int>() {		}, new List<int>(){		}	),
new News( 	2	,	"Sangrientos enfrentamientos"	,	"Los enfrentamientos liderados por el impostor Albatros ensangrentan la ciudad. Pesimismo en las calles."	,	""	,	0.05	,	0.1	,	-0.1	,	-0.05	,	0	,	0	,	1	, new List<int>() {		}, new List<int>(){		}	),
new News( 	3	,	"Romance confirmado"	,	"Se vio volando juntos a Paloma Heyera y el Pájaro Caniyia. Todo es hermoso."	,	""	,	0.01	,	0.03	,	0.01	,	0.03	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	4	,	"Paro de gallos madrugadores"	,	"El pueblo llega tarde a sus trabajos mientras los gallos reclaman aumento."	,	""	,	0.02	,	0.04	,	-0.03	,	-0.02	,	-0.03	,	-0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	5	,	"Huelga de pelícanos"	,	"Escasean los peces, el pueblo debe recurrir a alimentarse solamente de semillas."	,	""	,	0.01	,	0.03	,	-0.03	,	-0.01	,	-0.02	,	-0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	6	,	"Retraso de cigüeñas"	,	"El crecimiento poblacional decae, cae el precio del metro cuadrado de nido."	,	""	,	0.01	,	0.03	,	-0.03	,	-0.01	,	-0.02	,	-0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	7	,	"Pajaronia sede"	,	"La ciudad capital será la anfitriona de los Juegos Aviolímpicos. Grandes expectativas de turismo."	,	""	,	0.01	,	0.02	,	0.01	,	0.05	,	0.01	,	0.03	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	8	,	"Halcones semifinalistas"	,	"El equipo de los halcones llega a la final del mundial de garraball."	,	""	,	0.02	,	0.04	,	0.02	,	0.04	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	9	,	"Migraciones de golondrinas"	,	"Las golondrinas, acorraladas por la segregación, deciden emigar, como todos los años."	,	""	,	0	,	0.01	,	0	,	0.01	,	0	,	0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	10	,	"Caranchotti en problemas"	,	"Jefe de Gabinete encontrado en el VIP de un boliche con 500 g de birdnip y un huevo menor de edad."	,	""	,	0.05	,	0.1	,	-0.1	,	-0.05	,	-0.03	,	-0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	11	,	"Renuncian a Caranchotti"	,	"Tras haber sido encontrado con estupefacientes y menores ilegales, Jefe de Gabinete renuncia en medio de un escándalo."	,	""	,	0.01	,	0.04	,	0.01	,	0.04	,	-0.05	,	0.05	,	0	, new List<int>() {	10	}, new List<int>(){	12	}	),
new News( 	12	,	"Caranchotti pide disculpas"	,	"Caranchotti pide disculpas y dice, quien no se comió un huevo crudo alguna vez?"	,	""	,	-0.06	,	-0.03	,	0.01	,	0.02	,	-0.02	,	-0.01	,	0	, new List<int>() {	10	}, new List<int>(){	11	}	),
new News( 	13	,	"Plaza Central galardonada"	,	"La Plaza Central de Pajaronia ha sido galardonada como la más limpia de Pajaroamérica, con tan sólo un busto manchado de blanco."	,	""	,	0	,	0.01	,	0	,	0.01	,	0	,	0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	14	,	"Golpe al Sindicalismo"	,	"El gobierno recortó aportes al sindicato de pajaros carpinteros. Amenazas de termitas."	,	""	,	-0.01	,	0.01	,	0.01	,	0.04	,	-0.05	,	0.05	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	15	,	"Se reúne Bandada"	,	"Tras 10 años desde su último recital, 3 de los 5 integrantes de Bandada vuelven al escenario con sus hits clásicos."	,	""	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	16	,	"Estreno de Perdices Salvajes"	,	"Se estrena la nueva pelicula del aclamado director Damián Pajarón. Alta expectativa de la crítica."	,	""	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	17	,	"Por romper el cascarón"	,	"La hija del General Albatros está a punto de romper el cascarón. Será feriado nacional."	,	""	,	-0.03	,	-0.01	,	0.02	,	0.03	,	-0.01	,	0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	18	,	"Se aprueban nuevas leyes proteccionistas"	,	"El gobierno aprueba nuevas leyes proteccionistas. Desazón de los importadores de nidos premium."	,	""	,	-0.01	,	0	,	0.01	,	0.04	,	-0.02	,	0.02	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	19	,	"Conflicto de divas"	,	"La Garza Giménes fustigó a la Urraca Casandra. Tensión en la farándula."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	20	,	"Robo y muerte en San Aguilar"	,	"La localidad bonvientense trastornada tras un violento robo a mano armada que acabó en tragedia."	,	""	,	0.02	,	0.05	,	0.01	,	0.02	,	-0.03	,	0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	21	,	"Ansiedad"	,	"Faltan 364 días para la época migratoria estival."	,	""	,	-0.03	,	-0.02	,	-0.03	,	-0.02	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	22	,	"Ganan los Carroñeros"	,	"Tras un intenso enfrentamiento, los Carroñeros vencen a los Palomos Mensajeros por 10 a 1."	,	""	,	0.01	,	0.02	,	0.01	,	0.02	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){	40	}	),
new News( 	23	,	"Desfile de moda"	,	"Desfile de alta pluma en Punta Cogotes. Nueva colección causa expectativa." 	,	""	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	24	,	"Manifestación de horneros"	,	"Horneros se manifestarán mañana frente al Congreso Avícola antes el alza de impuestos para materiales de construcción."	,	""	,	0.02	,	0.04	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	25	,	"Represión en manifestación"	,	"Último momento. Dura represión en manifestación de horneros. Varios heridos."	,	""	,	0.02	,	0.04	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	26	,	"Murió manifestante"	,	"Roberto Picchotti, hornero constructor, murió en la dura represión del régimen de Albatros."	,	""	,	0.03	,	0.06	,	-0.03	,	-0.02	,	-0.04	,	-0.02	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	27	,	"Murió violento vándalo"	,	"Roberto Picchotti, hornero agitador, murió asaltando el Congreso de la Nación."	,	""	,	-0.06	,	-0.03	,	0.02	,	0.03	,	0.02	,	0.04	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	28	,	"Palomos destruyen estadio"	,	"Tras la aplastante derrota de los Palomos Mensajeros, los hinchas enfurecidos destruyen el estadio de Los Carroñeros."	,	""	,	0	,	0.01	,	0	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	29	,	"Jubilado rebelde"	,	"Jubilado asalta a efectivos policiales mientras intentaban contener una turba enfurecida."	,	""	,	-0.05	,	-0.01	,	0	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	30	,	"Mas vale pájaro en mano"	,	"La policía actuó rápidamente capturando a un malechor en pleno acto, declaro que fue gracias al gran entrenamiento policial."	,	""	,	-0.04	,	-0.01	,	0.01	,	0.02	,	0.01	,	0.02	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	31	,	"Corre riesgo la libertad de prensa"	,	"Fuentes cercanas al gobierno revelaron el plan de expropiación de los medios opositores. Alerta en organismos de libertad de prensa."	,	""	,	0.03	,	0.06	,	-0.01	,	-0.02	,	-0.04	,	-0.02	,	20	, new List<int>() {	52	}, new List<int>(){		}	),
new News( 	32	,	"Caranchotti vuelve a las andadas"	,	"Se esparce foto de Caranchotti desplumado en lujoso hotel."	,	""	,	0.03	,	0.06	,	-0.01	,	-0.02	,	-0.04	,	-0.02	,	0	, new List<int>() {	12	}, new List<int>(){		}	),
new News( 	33	,	"El último vuelo"	,	"Caranchotti renuncia tras reiterados escándalos. Me hicieron un nido, graznó fuertemente. Alivio en el gobierno."	,	""	,	0.01	,	0.04	,	0.01	,	0.04	,	-0.05	,	0.05	,	0	, new List<int>() {	32	}, new List<int>(){	34	}	),
new News( 	34	,	"Escándalo por docena"	,	"Caranchotti in fraganti recostado sobre maple de huevos. Impunidad total en altos funcionarios del gobierno"	,	""	,	-0.04	,	-0.01	,	0.01	,	0.02	,	0.01	,	0.02	,	0	, new List<int>() {	32	}, new List<int>(){	33	}	),
new News( 	35	,	"Halcones Campeones"	,	"Los Halcones son los campeones indiscutidos del mundial de garraball, algarabío infinito"	,	""	,	0.02	,	0.04	,	0.02	,	0.04	,	0	,	0	,	0	, new List<int>() {	8	}, new List<int>(){	36	}	),
new News( 	36	,	"Halcones bajados de un gomerazo"	,	"El equipo de los halcones pierde la final del mundial de garraball, nunca vi tantos pechofrios juntos, refunfuño un fan"	,	""	,	0.02	,	0.04	,	0.02	,	0.04	,	0	,	0	,	0	, new List<int>() {	8	}, new List<int>(){	35	}	),
new News( 	37	,	"Ansiedad Invernal"	,	"Faltan 183 días para el frío."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {	39	}, new List<int>(){		}	),
new News( 	38	,	"Ansiedad Otoñal"	,	"Faltan 123 días para la caída de hojas."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {	37	}, new List<int>(){		}	),
new News( 	39	,	"Ansiedad Primaveral"	,	"Faltan 274 días para las flores."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {	21	}, new List<int>(){		}	),
new News( 	40	,	"Ganan los Palomos"	,	"Tras un intenso enfrentamiento, los Palomos Mensajeros vencen a los Carroñeros por 8 a 5."	,	""	,	0.01	,	0.02	,	0.01	,	0.02	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){	22	}	),
new News( 	41	,	"El Cardenal"	,	"La película mas taquillera de Gilgero Manso."	,	""	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	42	,	"El ultimo Faisán"	,	"La galardonada serie ahora en la pantalla grande."	,	""	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	43	,	"Pulp Pingüin"	,	"1:30 hs de pura adrenalina."	,	""	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	44	,	"Los aleteos del Colibrí"	,	"Un frenético drama de un amor prohibido."	,	""	,	-0.01	,	0.01	,	-0.01	,	0.01	,	0	,	0	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	45	,	"Siempre nos respetamos"	,	"La Garza Giménes declaro que aunque haya diferencias siempre se respetaron con la Urraca. Se calman las aguas de los radiopasillos."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {	19	}, new List<int>(){		}	),
new News( 	46	,	"Se cuelga de mis alas"	,	"Urraca Casandra desmiente la falsa calma que aparenta la Garza y sostiene, es mas berreta que alpiste de gallinero."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {	46	}, new List<int>(){		}	),
new News( 	47	,	"Giménes se defiende"	,	"Hace rato que nadie le arrastra el ala a la Urraca, sostiene desde el estudio."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {	47	}, new List<int>(){		}	),
new News( 	48	,	"Divas y algo más"	,	"Avistaron a La Garza Giménes y a la Urraca Casandra a los besos en la playa del Pato Lucas,  estaban mas calientes que la arena dijo una Paloma que pasaba."	,	""	,	-0.02	,	-0.01	,	-0.02	,	-0.01	,	0	,	0	,	0	, new List<int>() {	48	}, new List<int>(){		}	),
new News( 	49	,	"Justicia por Roberto"	,	"Marchan las palomas por el asesinato de Roberto Picchotti, el hornero constructor."	,	""	,	0.03	,	0.06	,	-0.03	,	-0.02	,	-0.04	,	-0.02	,	0	, new List<int>() {	26	}, new List<int>(){		}	),
new News( 	50	,	"Los Picchotti piden a gritos"	,	"La familia de Roberto Picchotti reclaman justicia al gobierno y que se hagan cargo de lo que hicieron."	,	""	,	0.03	,	0.06	,	-0.03	,	-0.02	,	-0.04	,	-0.02	,	0	, new List<int>() {	26,49	}, new List<int>(){		}	),
new News( 	51	,	"Reunión de manifestantes"	,	"Se reunen pajaros de todo tipo por el encubrimiento del asesinato de Roberto por parte del gobierno."	,	""	,	0.03	,	0.06	,	-0.03	,	-0.02	,	-0.04	,	-0.02	,	0	, new List<int>() {	26,49,50	}, new List<int>(){		}	),
new News( 	52	,	"Dictador clausura el congreso"	,	"Se clausuran las sesiones del congreso a la fuerza, Pajaronia acongojada."	,	""	,	0.05	,	0.1	,	-0.2	,	-0.1	,	-0.04	,	-0.02	,	7	, new List<int>() {		}, new List<int>(){		}	),
new News( 	53	,	"Congreso traidor obtiene su merecido"	,	"El Presidente General Albatros clausura las sesiones del traidor Congreso. Pueblo festeja. Diputados enviados a sus casa."	,	""	,	-0.2	,	-0.1	,	0.05	,	0.1	,	0.01	,	0.02	,	7	, new List<int>() {		}, new List<int>(){		}	),
new News( 	54	,	"Presidente Albatros nacionaliza YLF"	,	"Yacimientos Lombricisticos Fiscales vuelve a ser del pueblo, tras 50 años de estas en manos extranjeras."	,	""	,	-0.05	,	-0.01	,	0.01	,	0.05	,	0.02	,	0.04	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	55	,	"Fondos Buitres amenazan a Pajaronia"	,	"Fondos Buitres amenazan a Pajaronia, pero el presidente Albatros contesta que jamás pagaremos a los buitres."	,	""	,	-0.05	,	-0.01	,	0.01	,	0.05	,	0.02	,	0.04	,	0	, new List<int>() {		}, new List<int>(){		}	),
new News( 	56	,	"Presidente propone nueva bandera"	,	"El presidente Albatros propone una nueva bandera para Pajaronia. Es un hermoso diseño."	,	""	,	-0.02	,	-0.01	,	0.05	,	0.1	,	0.01	,	0.02	,	0	, new List<int>() {		}, new List<int>(){		}	),

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
