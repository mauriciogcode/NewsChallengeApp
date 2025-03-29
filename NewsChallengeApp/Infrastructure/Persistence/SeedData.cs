using Microsoft.EntityFrameworkCore;
using NewsApi.Domain.Entities;
using System;

namespace NewsApi.Infrastructure.Persistence;

public static class SeedData
{
    public static void Initialize(NewsDbContext context)
    {
        if (context.News.Any()) return;

        var now = DateTime.UtcNow;

        context.News.AddRange(
            new News
            {
                Title = "Nueva versión de .NET lanzada con mejoras en rendimiento",
                Body = "Microsoft ha anunciado el lanzamiento de la nueva versión de .NET con importantes mejoras en rendimiento y nuevas características para desarrolladores. Entre las novedades destacan optimizaciones en el recolector de basura, mejor soporte para contenedores y una nueva API para manipulación de JSON que promete ser hasta 30% más rápida que las soluciones actuales.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "María Rodríguez",
                Date = now.AddDays(-1)
            },

            new News
            {
                Title = "Avances en inteligencia artificial revolucionan el sector salud",
                Body = "Nuevos algoritmos de aprendizaje profundo están permitiendo diagnósticos médicos más precisos y personalizados. Un equipo internacional de investigadores ha desarrollado un sistema capaz de detectar enfermedades cardíacas con una precisión superior al 95%, superando a médicos especialistas en pruebas controladas. 'Esto no reemplazará a los médicos, sino que será una herramienta poderosa para asistirlos en su trabajo diario', comentó el líder del proyecto.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Carlos Jiménez",
                Date = now.AddDays(-3)
            },

            new News
            {
                Title = "Equipo local consigue victoria histórica en campeonato nacional",
                Body = "En un partido lleno de emoción, el equipo local logró una victoria histórica que los coloca por primera vez en semifinales del campeonato nacional. Con un marcador final de 3-1, los jugadores demostraron gran técnica y espíritu de equipo ante más de 35,000 espectadores que llenaron el estadio. El entrenador declaró: 'Este es el resultado de años de trabajo duro y dedicación'.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Diego Martínez",
                Date = now.AddDays(-2)
            },

            new News
            {
                Title = "Atleta rompe récord mundial en maratón",
                Body = "En una actuación espectacular, el atleta internacional ha batido el récord mundial de maratón con un tiempo de 2 horas, 1 minuto y 3 segundos. La carrera, que tuvo lugar en condiciones climáticas ideales, atrajo a los mejores corredores del mundo y miles de aficionados que presenciaron el momento histórico. Este logro marca un antes y un después en el atletismo moderno.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Laura Gómez",
                Date = now.AddDays(-5)
            },

            new News
            {
                Title = "Parlamento aprueba nueva ley de protección ambiental",
                Body = "Tras meses de debates, el Parlamento aprobó por amplia mayoría una nueva ley de protección ambiental que establece límites más estrictos para emisiones industriales y crea un fondo nacional para la conservación de ecosistemas en peligro. Las empresas tendrán un plazo de tres años para adaptar sus instalaciones a los nuevos requisitos, mientras que las pequeñas empresas recibirán subsidios para facilitar la transición.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Javier López",
                Date = now.AddDays(-7)
            },

            new News
            {
                Title = "Elecciones regionales programadas para octubre",
                Body = "La autoridad electoral ha anunciado oficialmente que las próximas elecciones regionales se celebrarán el segundo domingo de octubre. Se espera una participación récord, con más de 12 millones de votantes registrados. Los principales partidos ya han comenzado sus campañas, centrándose en temas como el empleo, la seguridad y el desarrollo de infraestructuras.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Ana Martín",
                Date = now.AddDays(-10)
            },

            new News
            {
                Title = "Inflación alcanza su nivel más bajo en cinco años",
                Body = "Según datos oficiales publicados hoy, la tasa de inflación anual ha descendido al 1.3%, su nivel más bajo en los últimos cinco años. Los economistas atribuyen esta caída a la estabilidad en los precios de la energía y a una política monetaria efectiva. Este dato favorable podría traducirse en una reducción de las tasas de interés en los próximos meses, según analistas del sector financiero.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Roberto Fernández",
                Date = now.AddDays(-4)
            },

            new News
            {
                Title = "Nueva startup local recibe inversión millonaria",
                Body = "Una startup local dedicada al desarrollo de soluciones de energía renovable ha recibido una inversión de 50 millones de dólares de un consorcio internacional. La empresa, fundada hace apenas tres años por tres jóvenes ingenieros, planea utilizar estos fondos para expandir sus operaciones a nivel internacional y duplicar su plantilla en los próximos 18 meses. 'Este es un voto de confianza en nuestro modelo de negocio y tecnología', declaró su CEO.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Elena Sánchez",
                Date = now.AddDays(-6)
            },

            new News
            {
                Title = "Festival de cine local anuncia programación completa",
                Body = "El comité organizador del Festival Internacional de Cine ha anunciado la programación completa de su décima edición, que incluirá más de 100 películas de 35 países diferentes. El evento, que se celebrará del 15 al 25 del próximo mes, contará con la presencia de reconocidos directores y actores internacionales. El film de apertura será el último trabajo de un aclamado director que ha cosechado éxitos en festivales como Cannes y Venecia.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Pablo Moreno",
                Date = now.AddDays(-8)
            },

            new News
            {
                Title = "Descubren pinturas rupestres de más de 10,000 años de antigüedad",
                Body = "Un equipo de arqueólogos ha descubierto un conjunto de pinturas rupestres con una antigüedad estimada de más de 10,000 años en una cueva remota. Las imágenes, que representan escenas de caza y rituales, se encuentran en un estado de conservación excepcional debido a las condiciones climáticas estables de la cueva. Expertos califican el hallazgo como 'uno de los más importantes de la década' para entender las sociedades prehistóricas de la región.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Sofía Torres",
                Date = now.AddDays(-12)
            },

            new News
            {
                Title = "Científicos desarrollan nueva técnica para capturar CO2 atmosférico",
                Body = "Un equipo internacional de científicos ha desarrollado una nueva técnica que permite capturar dióxido de carbono directamente de la atmósfera con un costo energético 40% menor que los métodos actuales. La tecnología, basada en materiales porosos avanzados, podría ser clave en la lucha contra el cambio climático si se implementa a gran escala. Los primeros prototipos industriales podrían estar operativos en menos de tres años, según los investigadores.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Miguel Ángel Ruiz",
                Date = now.AddDays(-9)
            },

            new News
            {
                Title = "Misión espacial completa primer mapeo detallado de luna de Júpiter",
                Body = "La sonda espacial ha completado con éxito el primer mapeo detallado de Europa, una de las lunas de Júpiter, revelando nuevos datos sobre su océano subsuperficial y su potencial para albergar vida. Las imágenes de alta resolución muestran características geológicas nunca antes observadas, incluidas posibles plumas de vapor de agua. Los científicos procesarán estos datos durante los próximos meses para preparar futuras misiones de exploración.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Carmen Vega",
                Date = now.AddDays(-15)
            },

            new News
            {
                Title = "Nuevo tratamiento muestra resultados prometedores contra el Alzheimer",
                Body = "Ensayos clínicos de fase III han demostrado resultados prometedores de un nuevo tratamiento contra el Alzheimer, logrando ralentizar significativamente la progresión de la enfermedad en pacientes en etapas tempranas. El medicamento, que utiliza anticuerpos monoclonales para eliminar las placas amiloides del cerebro, podría estar disponible para pacientes en dos años, pendiente de aprobación regulatoria. Expertos describen estos resultados como 'un paso importante en la dirección correcta'.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Isabel Reyes",
                Date = now.AddDays(-11)
            },

            new News
            {
                Title = "Estudio revela beneficios de la meditación en la salud cardiovascular",
                Body = "Una investigación a largo plazo con más de 5,000 participantes ha revelado que la práctica regular de meditación durante al menos 15 minutos diarios está asociada con una reducción del 30% en el riesgo de enfermedades cardiovasculares. Los investigadores observaron mejoras en la presión arterial, reducción del estrés y mejor calidad del sueño en los participantes que mantuvieron la práctica durante el período de estudio de cinco años.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Fernando Álvarez",
                Date = now.AddDays(-14)
            },

            new News
            {
                Title = "Vehículos autónomos comienzan pruebas en entorno urbano real",
                Body = "Una importante empresa tecnológica ha iniciado pruebas de su flota de vehículos autónomos en entorno urbano real, tras obtener los permisos necesarios de las autoridades locales. Los vehículos, equipados con docenas de sensores y sistemas de inteligencia artificial avanzados, circularán inicialmente con un conductor de seguridad, pero se espera que en seis meses puedan operar completamente sin supervisión humana. El proyecto busca demostrar la viabilidad de esta tecnología para el transporte público del futuro.",
                ImageUrl = "https://picsum.photos/200/300",
                Author = "Lucía Méndez",
                Date = now.AddDays(-2)
            }
        );

        context.SaveChanges();
    }
}