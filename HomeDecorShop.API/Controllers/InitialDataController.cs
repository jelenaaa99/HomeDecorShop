using Microsoft.AspNetCore.Mvc;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDecorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private readonly HomeDecorContext _context;
        public InitialDataController(HomeDecorContext context)
        {
            _context = context;
        }

        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {

            if (_context.Categories.Any())
            {
                return Conflict();
            }

            var categories = new List<Category>
            {
                new Category { Name="Sofas and couches" },
                new Category { Name="Chairs" },
                new Category { Name="Tables" },
                new Category { Name="Lounge Sets" },
                new Category { Name="Dining Sets" },
                new Category { Name="Swings" },
                new Category { Name="Chandelier" }
            };

            var users = new List<User>
            {
                new User { FirstName="Pera", 
                           LastName="Peric",
                           Email="pera@gmail.com",
                           Password="$2a$11$EkBGkMFfR4265JbmiLa09Ocu.aMpb/8e.GVQj4VN9vFpAH.oIdF7q",
                           Country="Srbija",
                           City="Beograd", 
                           Address="Balkanska 12", 
                           Phone="065879126" },
                new User { FirstName="Mika",
                           LastName="Mikic",
                           Email="mika@gmail.com",
                           Password="$2a$11$7xeqAtg3FxlNUm.UoBgpfOC2Lct9gUwWXFn4OqmdlsuttzomL5Nsy",
                           Country="Srbija",
                           City="Niš",
                           Address="Vojvode Misica 5",
                           Phone="062457963" },
                new User { FirstName="Mara",
                           LastName="Ilic",
                           Email="marai@gmail.com",
                           Password="$2a$11$.o74wLMSOn1QEBFvD.RFy.F5PbtwKAoyj4.KXDz2tZDjrXod773dS",
                           Country="Crna Gora",
                           City="Podgorica",
                           Address="Njegoseva 32",
                           Phone="067895412" },
                new User { FirstName="Jelena",
                           LastName="Biševac",
                           Email="bisevacjelena1@gmail.com",
                           Password="$2a$11$cjmAVTGHlEvnNllS0JFqe.sWk8bv60fnL/0l0v8mrec/53omKMWKK",
                           Country="Srbija",
                           City="Beograd",
                           Address="Bulevar vojvode Mišića 19",
                           Phone="063331785" },
            };

            var products = new List<Product>
            {
                new Product
                {
                    Name="Left Hand Velvet Corner Sofa Teal ABERDEEN",
                    Description="This large corner sofa is an ideal anchor piece for your living room, inviting and homely. Versatile in design, the sofa can be turned into a comfortable bed for two thanks to the adjustable backrest. Additionally, the chaise can be positioned on either side to suit your needs. Fully upholstered in high-quality, rich teal fabric with elegant tufting, this corner sofa offers both functionality and timeless style that will highlight the best of any modern home. The whole piece is kept stable thanks to metal legs.",
                    Price=899,
                    Img="sofa1.jpg",
                    Category=categories.ElementAt(0)
                },
                new Product
                {
                    Name="Set of 2 Wooden Dining Chairs Grey LYNN",
                    Description="A set of two modern dining chairs in stylish, unique design. The natural wooden frame and beautiful grey faux leather upholstery are a perfect fit for any interior. High, curved backrest supports correct body posture, while the high-quality materials guarantee durability and timeless elegance. Pair the chair with a matching table in your dining room or kitchen and enjoy the designer look, as well as a comfortable, inviting dining space.",
                    Price=209,
                    Img="chair1.jpg",
                    Category=categories.ElementAt(1)
                },
                new Product
                {
                    Name="Wooden Dining Table Light Wood and White",
                    Description="Create a lovely dining space with this elegant wooden table. It perfectly fits many interiors, from minimalistic and Scandinavian to a classic cottage dining room or kitchen. The combination of natural light wood and the black colour makes the room look fresh and lively. The table offers ample space for four people. Its solid construction and high-quality materials guarantee long-term use and easy maintenance.",
                    Price=209,
                    Img="table1.jpg",
                    Category=categories.ElementAt(2)
                },
                new Product
                {
                    Name="2 Seater PE Rattan Garden Lounge Set Natural PONZA",
                    Description="Recline and relax on a comfortable garden set for two. Consist of two high back armchairs paired with matching footstools and perfectly tailored thick pillows, it offers a cosy place to rest during a warm evening. It comes with a small coffee table with tempered glass top and additional shelf for books, magazines or decorations. With a frame crafted from sturdy aluminium and durable faux rattan body, this set withstands adverse weather conditions. The pieces are easy to maintain and the seating cushions can be washed and refreshed thanks to the zipped covers. The set looks perfect when matched with traditional or boho accessories.",
                    Price=959,
                    Img="loungeset1.jpg",
                    Category=categories.ElementAt(3)
                },
                new Product
                {
                    Name="6 Seater Dining Set Dark Wood with Black REDOLA",
                    Description="Inspired by industrial design, this 7- piece dining set is sure to be a functional as well as a trendy focal point of any room. The hard-wearing steel construction is matched with weathered wood look MDF for a rustic look. With its straightforward, raw appearance, the set will blend smoothly into the interiors in a vintage, minimalistic or contemporary style.",
                    Price=429,
                    Img="diningset1.jpg",
                    Category=categories.ElementAt(4)
                },
                new Product
                {
                    Name="Wooden Garden Swing Light Wood and White APRILIA",
                    Description="This outstanding garden swing adds a charming atmosphere to any garden! Unique design and slightly curved shape mix with high functionality. The all-weather wood construction is durable and comes in a warm, teak finish that accentuates the white upholstery. The easy-care seat cover can be cleaned with a damp sponge. The swing is exceptionally stable and comfortable. A chain and suspension clips are crafted from steel.",
                    Price=489,
                    Img="swing1.jpg",
                    Category=categories.ElementAt(5)
                },
                new Product
                {
                    Name="6 Light Metal Chandelier Silver BRADANO",
                    Description="This elegant ambient lamp is a modern take on a classic chandelier. The design features six lights surrounded by bright shades made from high-quality acrylic. They are suspended on a curved frame finished in high gloss chrome. The fixture brings a glamorous touch to a hallway or entertaining area in any modern as well as a traditional home.",
                    Price=109,
                    Img="chandelier1.jpg",
                    Category=categories.ElementAt(6)
                },
                new Product
                {
                    Name="3 Seater Velvet Sofa Grey EIKE",
                    Description="This cosy velvet sofa is a real eye-catcher, infusing your living room with a soft vintage feel. Designed to bring to your home a chic and old-fashion homely mood, it features ornate, wooden legs, rolled arms and a soft fabric that will maintain its rich colour for years. The generously padded cushions and matching toss pillows complement the piece, creating a beautifully cosy composition.",
                    Price=779,
                    Img="sofa2.jpg",
                    Category=categories.ElementAt(0)
                },
                new Product
                {
                    Name="7 Seater Curved Fabric Modular Sofa Grey ROTUNDE",
                    Description="Define your living room style with this round sectional fabric sofa. The circular design and generous seating ensure that the sofa becomes a focal point of any contemporary and modern interior. The high quality, durable grey fabric covers the soft padding and ensures that you will treasure this piece for years to come.",
                    Price=2399,
                    Img="sofa3.jpg",
                    Category=categories.ElementAt(0)
                },
                new Product
                {
                    Name="Fabric Sofa Bed Grey and Blue Patchwork INGARO",
                    Description="Created for functionality, this modern sofa is fully adaptable to your needs. The armrests recline in 3 stages, allowing for comfy sitting or napping positions. With the adjustable backrest, you can easily go for a semi-reclined position, while the click-clack mechanism allows quick conversion into a single bed. Generous foam padding, and tailoring in square quilted upholstery is highlighted by slim metal legs in wood-like finish.",
                    Price=369,
                    Img="sofa4.jpg",
                    Category=categories.ElementAt(0)
                },
                new Product
                {
                    Name="Leather Living Room Set Cream HELSINKI",
                    Description="Ultra-stylish with its streamlined simplicity, this set will transform any living space into the ultimate lounge. The sofa set comes with a 3-seater, a 2-seater loveseat and a club chair. Each piece features a robust frame and stable, metal legs for the utmost comfort. Split leather on all seating surfaces, including back and armrests, ensures durability. High-grade synthetic leather is an economical solution for sides, bottom, and backside.",
                    Price=1719,
                    Img="sofa5.jpg",
                    Category=categories.ElementAt(0)
                },
                new Product
                {
                    Name="Set of 2 Velvet Dining Chairs Taupe Beige JASMIN",
                    Description="Conveying the features of the minimalistic and luxurious design, this chair boasts a timeless look that works great styled with any modern or traditional home furnishing. The seat’s clean-lined contours are tailored in taupe velvet upholstery with tufted details. The smooth texture and the light tone can add chic to a room décor or calm down bold colour scheme. Completed with slim metal legs, the chair suits by a dining table as well as in a bedroom or home library.",
                    Price=279,
                    Img="chair2.jpg",
                    Category=categories.ElementAt(1)
                },
                new Product
                {
                    Name="Set of 2 Fabric Dining Chairs Light Brown ROSLYN",
                    Description="Introduce a stylish retro vibe to your dining room or kitchen with this unique chair set. Upholstered in high-quality fabric, each chair features a deep, comfortable seat and slender wooden legs that perfectly underline the mid-century look. The rounded gaps in the backrests create a bold, eye-catching accent. Thanks to the high-quality material, the chairs are easy-care and maintain their fresh, unique look for years.",
                    Price=169,
                    Img="char3.jpg",
                    Category=categories.ElementAt(1)
                },
                new Product
                {
                    Name="Set of 2 Wooden Dining Chairs Black BURBANK",
                    Description="Make a statement with minimalism with these durable and sleek wooden chairs. Made from durable solid wood and painted black, the chairs have a lacquered, glossy finish. The wide seat is complemented by a slanted, slatted backrest adding a twist to this classic design to create a Scandi-inspired look. Pair them with a table in the dining room, or enjoy them on their own in the kitchen or living room.",
                    Price=159,
                    Img="chair4.jpg",
                    Category=categories.ElementAt(1)
                },
                new Product
                {
                    Name="Set of 2 Faux Leather Dining Chairs Beige BROADWAY",
                    Description="Inspired by Scandinavian design, the dining chairs become one of the most comfortable seats in your home. High-quality faux leather gives them a sophisticated look while being effortless to maintain and soft to touch. Sturdy rubberwood legs guarantee chairs' stability and durability to withstand prolonged usage. Chic looking, they complement virtually any modern decor.",
                    Price=109,
                    Img="chair5.jpg",
                    Category=categories.ElementAt(1)
                },
                new Product
                {
                    Name="Dining Table 140 x 80 cm Dark Wood - Black SPECTRA",
                    Description="Add an instant upgrade to your dining area with this industrial-inspired table. The piece features a durable, high-quality MDF table top in warm tones of brown, and is based on steady, metal legs in black, making it blend perfectly with any modern or warehouse home decor. The table can seat up to 6 people thus it's ideal for any family dinner or friends’ gathering.",
                    Price=409,
                    Img="table2.jpg",
                    Category=categories.ElementAt(2)
                },
                new Product
                {
                    Name="Extending Dining Table 180/220 x 90 cm HAMLERL",
                    Description="Perfectly contemporary and classic at the same time, this table is sure to make a statement in your interior. Clean-lined, straightforward design enhanced by the white glossy surface is a perfect match with minimalistic home décor. Designed with butterfly feature, the table easily extends so that you can sit up to 8 guests.",
                    Price=649,
                    Img="table3.jpg",
                    Category=categories.ElementAt(2)
                },
                new Product
                {
                    Name="Dining Table 180 x 90 cm Light Wood -Black ADENA",
                    Description="Designed to implement the industrial and clubhouse feel to any space, the dining table blends perfectly with any room with a warehouse or loft decor. The table features a durable, thick MDF top with sturdy metal hairpin legs that give stability and strength. Finished in warm tones of light wood, the table works excellently with interiors in minimalist, vintage or urban style.",
                    Price=499,
                    Img="table4.jpg",
                    Category=categories.ElementAt(2)
                },
                new Product
                {
                    Name="Coffee Table Marble Effect White - Gold MERIDIAN",
                    Description="The coffee table brings an art deco design and mid-century flair to your home office or living room. The round table features gold hairpin legs and a white tempered glass table top with marble effect finish which gives the design an opulent and elegant look. This timeless table will complement an array of home décor styles, from retro to modern and glam.",
                    Price=169,
                    Img="table5.jpg",
                    Category=categories.ElementAt(2)
                },
                new Product
                {
                    Name="4 Seater Rattan Garden Sofa Set White SAN MARINO",
                    Description="Bring summer atmosphere and luxurious design to your garden with this elegant sofa set. This trendy furniture features long-lasting poly rattan and creates an inviting lounging area. The highest level of comfort is achieved thanks to the generously padded seat and back cushions in a neutral shade of grey. The set comes complete with a complimentary side table that features a clear glass top which provides ample space for your coffee and snacks.",
                    Price=1299,
                    Img="loungeset2.jpg",
                    Category=categories.ElementAt(3)
                },
                new Product
                {
                    Name="4 Seater Acacia Wood Garden Corner Sofa Set TIMOR",
                    Description="This classic garden sofa set comes with a coffee table and 4 seats that can be combined into a cosy corner sofa or used separately. Made from certified, acacia in a beautiful, light tone of the wood, it is perfect for outdoor lounging area and easy to clean. With the thickly padded seat and backrest cushions combined with comfortable, low design frame, this is the perfect focal point for any modern garden or patio.",
                    Price=1219,
                    Img="loungeset3.jpg",
                    Category=categories.ElementAt(3)
                },
                new Product
                {
                    Name="4 Seater Aluminium Garden Sofa Set Dark Grey DELIA",
                    Description="Prepare your outdoor area for the summer with this stylish, modern garden set. Consisting of a two-seater sofa, armchairs and a rectangular coffee table, the set will provide enough space for you and your friends to enjoy sunny weather and relax on your patio. Every seat comes with a thick cushion in dark grey colour, which additionally elevates the comfort of usage. The frames are made out of low-maintenance aluminium and are finished with wood-like material on the armrests.",
                    Price=889,
                    Img="loungeset4.jpg",
                    Category=categories.ElementAt(3)
                },
                new Product
                {
                    Name="7 Seater Acacia Wood Garden Lounge Set Grey PATAJA",
                    Description="A complete outdoor conversation set that consists of a garden lounger, a side table and three garden seats of different sizes. It is constructed from exceptionally sturdy acacia wood and is oiled for additional protection. The furniture is incredibly durable. Separate seats and a lounger allow for quick rearrangements. The set comes with matching cushions crafted from a sturdy yet durable synthetic fabric and it is thickly padded for absolute comfort. An excellent choice that will allow you to enjoy summer afternoons for years to come.",
                    Price=1189,
                    Img="loungeset5.jpg",
                    Category=categories.ElementAt(3)
                },
                new Product
                {
                    Name="4 Seater Garden Dining Set Table with Chairs OLBIA",
                    Description="Elevate the look of your garden with this dining set consisting of a dining table and 4 chairs. All pieces are made of durable, weather-resistant elements. The tabletop is crafted out of fibre cement, which is easy to take care of, while the bases of the furniture are made of solid acacia wood, that underlines the minimalist, modern look of the set. The beige chairs feature a classic rope style backrest and a thick seat cushion for superb seating comfort. The eye-catching colour combination makes the furniture stand out and upgrade any area and decor style.",
                    Price=1129,
                    Img="diningset2.jpg",
                    Category=categories.ElementAt(4)
                },
                new Product
                {
                    Name="4 Seater Garden Dining Set Grey OLBIA/TARANTO",
                    Description="Enjoy fine dining in your garden thanks to this timeless set. Consisting of a table and four stools, it makes for a great addition to any modern outdoor space. The table top and stools are made from high-quality and robust fibre-cement, which is also exceptionally easy to take care of. The dark colour of the raw material is beautifully complemented by the acacia wooden base in natural finish. Whether in an industrial, minimalist or contemporary setting, this set is bound to take your garden dining to a whole new level.",
                    Price=879,
                    Img="diningset3.jpg",
                    Category=categories.ElementAt(4)
                },
                new Product
                {
                    Name="8 Seater Acacia Wood Garden Dining Set MAUI II",
                    Description="A functional 9-piece dining set crafted from acacia in a beautiful warm tone. Crafted with butterfly leaves as a highlighting decoration, the tabletop is easily extendable and features a pre-cut hole for the umbrella pole. The collapsible chair allows you to economise on space, while the high back guarantees comfortable sitting. With its classic yet simple design, the set blends well with any modern garden or patio decorating style.",
                    Price=1059,
                    Img="diningset4.jpg",
                    Category=categories.ElementAt(4)
                },
                new Product
                {
                    Name="6 Seater Garden Dining Set Benches Grey ORIA",
                    Description="Upgrade the look of your garden with this minimalist outdoor dining set. The tabletop as well as the seat of the bench is made of extremely durable fibre cement that not only introduces an industrial feel to the piece but is also very simple in maintenance. Natural looking robust, high-quality acacia wood legs guarantee sufficient stability.",
                    Price=1219,
                    Img="diningset5.jpg",
                    Category=categories.ElementAt(4)
                },
                new Product
                {
                    Name="Outdoor 3 Seater Swing Beige TEMPLE",
                    Description="Make your afternoon in the backyard even more enjoyable with this delightful garden swing. The seat is supported by sturdy, stain-resistant, powder coated steel frame with flexible springs, based on wide legs, guaranteeing exceptional stability with each swing. Thick seat upholstery provides excellent seating comfort for up to 3 people. The canopy provides soothing shade over the swing, gently protecting you from the sun's rays. A combination of classic and modern design, the swing is a versatile piece, which matches any outdoor decor.",
                    Price=329,
                    Img="swing2.jpg",
                    Category=categories.ElementAt(5)
                },
                new Product
                {
                    Name="3 Seater Garden Swing Grey BOGART",
                    Description="A delightful garden swing is a great addition to your outdoor space. Crafted with care and precision, it is made of powder-coated steel and synthetic fabric. Wide and comfortable seat swings delightfully in the shade of board canopy, protecting from sun rays and letting you enjoy a blissful relaxation.",
                    Price=289,
                    Img="swing3.jpg",
                    Category=categories.ElementAt(5)
                },
                new Product
                {
                    Name="3 Seater Garden Swing Blue and White CHAPLIN",
                    Description="A charming garden swing and an excellent addition to your outdoors, matching any modern decors well. Crafted with durable, powder-coated steel to ensure construction durability and stability during each swing. The canopy of sturdy synthetic fibre is stain-resistant while giving the swing a soothing shade during sunny seasons. The high backrest and wide, padded seating guarantee exceptional comfort for years to come.",
                    Price=139,
                    Img="swing4.jpg",
                    Category=categories.ElementAt(5)
                },
                new Product
                {
                    Name="Fabric Garden Swing Grey TESERO",
                    Description="A non-traditional garden swing that will fit in perfectly in a modern garden or patio. The sturdy powder-coated steel frame ensures its longevity whilst its gently rounded shape blends naturally into outdoor scenery. With ample room for two people, this swing offers a gentle motion for perfect relaxation at the end of a long day. The synthetic fabric is low-maintenance, and the handy adjustable canopy allows you to quickly switch between sun and shade for added convenience and versatility.",
                    Price=289,
                    Img="swing5.jpg",
                    Category=categories.ElementAt(5)
                },
                new Product
                {
                    Name="5 Light Crystal Chandelier Silver ASCAR",
                    Description="Add a touch of regal class to your living space with this stunning silver ambient chandelier. This lamp’s frame is crafted from high-quality iron and features a number of beautiful faux crystal beads. This dazzling array of acrylic glass elements make this lamp an impressive centrepiece to any living room, office or bedroom.",
                    Price=219,
                    Img="chandelier2.jpg",
                    Category=categories.ElementAt(6)
                },
                 new Product
                {
                    Name="6 Light Chandelier Silver Mucone",
                    Description="Generously embellished with silver chains, two curved, chromed metal bars placed one under another will create a focal point in any living area. The 6-light ambient ceiling lamp, emitting the warm and mellow light, features the solid aluminium suspension that matches the decorated shade perfectly. This glam chandelier will add a touch of glitz to any modern or traditional interior.",
                    Price=249,
                    Img="chandelier3.jpg",
                    Category=categories.ElementAt(6)
                },
                 new Product
                {
                    Name="Crystal Chandelier Silver ENTWASH",
                    Description="Generously embellished with silver chains, two curved, chromed metal bars placed one under another will create a focal point in any living area. The 6-light ambient ceiling lamp, emitting the warm and mellow light, features the solid aluminium suspension that matches the decorated shade perfectly. This glam chandelier will add a touch of glitz to any modern or traditional interior.",
                    Price=249,
                    Img="chandelier4.jpg",
                    Category=categories.ElementAt(6)
                },
                 new Product
                {
                    Name="8 Light Chandelier Black TEESTA",
                    Description="Introducing a bit of vintage glam and sophistication to modern and traditional interiors has never been easier. This ambient lamp, inspired by Victorian forms, will become an accent piece in any setting. The chandelier features black, glossy colouring which goes perfectly with bright interiors. The lamp accommodates eight candle lightbulbs that will illuminate any bedroom, dining room or living room with a soft and cosy light.",
                    Price=149,
                    Img="chandelier5.jpg",
                    Category=categories.ElementAt(6)
                }
            };

            var userUseCases = new List<UserUseCase>
            {
                new UserUseCase { User=users.ElementAt(0), UseCaseId=1 },
                new UserUseCase { User=users.ElementAt(0), UseCaseId=2 },
                new UserUseCase { User=users.ElementAt(0), UseCaseId=3 },
                new UserUseCase { User=users.ElementAt(0), UseCaseId=11 },
                new UserUseCase { User=users.ElementAt(0), UseCaseId=12 },

                new UserUseCase { User=users.ElementAt(1), UseCaseId=5 },
                new UserUseCase { User=users.ElementAt(1), UseCaseId=6 },
                new UserUseCase { User=users.ElementAt(1), UseCaseId=7 },
                new UserUseCase { User=users.ElementAt(1), UseCaseId=8 },
                new UserUseCase { User=users.ElementAt(1), UseCaseId=11 },
                new UserUseCase { User=users.ElementAt(1), UseCaseId=13 },
                new UserUseCase { User=users.ElementAt(1), UseCaseId=14 },
                new UserUseCase { User=users.ElementAt(1), UseCaseId=15 },

                new UserUseCase { User=users.ElementAt(2), UseCaseId=5 },
                new UserUseCase { User=users.ElementAt(2), UseCaseId=11 },

                new UserUseCase { User=users.ElementAt(3), UseCaseId=1 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=2 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=3 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=4 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=5 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=6 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=7 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=8 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=9 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=10 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=11 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=12 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=13 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=14 },
                new UserUseCase { User=users.ElementAt(3), UseCaseId=15 }
            };

            var orders = new List<Order>
            {
                new Order 
                { 
                    User = users.ElementAt(1), 
                    Country = "Srbija", 
                    City = "Beograd", 
                    Address = "Knez Mihailova",
                    Phone="061245789"
                },
                new Order
                {
                    User = users.ElementAt(0),
                    Country = "Srbija",
                    City = "Novi Sad",
                    Address = "Cvijićеva 5",
                    Phone="061245689"
                },
                new Order
                {
                    User = users.ElementAt(3),
                    Country = "Srbija",
                    City = "Beograd",
                    Address = "Bulevar vojvode Mišića 19",
                    Phone="063331785"
                }
            };

            var orderLines = new List<OrderLine>
            {
                new OrderLine
                {
                    Order = orders.ElementAt(0),
                    Product = products.ElementAt(5),
                    Quantity = 1
                },
                new OrderLine
                {
                    Order = orders.ElementAt(0),
                    Product = products.ElementAt(10),
                    Quantity = 2
                },
                new OrderLine
                {
                    Order = orders.ElementAt(1),
                    Product = products.ElementAt(7),
                    Quantity = 1
                },
                new OrderLine
                {
                    Order = orders.ElementAt(1),
                    Product = products.ElementAt(9),
                    Quantity = 2
                },
                new OrderLine
                {
                    Order = orders.ElementAt(2),
                    Product = products.ElementAt(17),
                    Quantity = 2
                },
                new OrderLine
                {
                    Order = orders.ElementAt(2),
                    Product = products.ElementAt(20),
                    Quantity = 4
                },
                new OrderLine
                {
                    Order = orders.ElementAt(2),
                    Product = products.ElementAt(32),
                    Quantity = 5
                },
            };

            _context.Categories.AddRange(categories);
            _context.Users.AddRange(users);
            _context.Products.AddRange(products);
            _context.UserUseCases.AddRange(userUseCases);
            _context.Orders.AddRange(orders);
            _context.OrderLines.AddRange(orderLines);

            _context.SaveChanges();

            return StatusCode(201);
        }

    }
}
