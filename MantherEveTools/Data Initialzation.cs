using System;
using System.Collections;
using System.Windows.Forms;

using METCommon;

namespace MantherEveTools
{
    public partial class fResearchTools : Form
    {
        // ---Define Image source for Products and Ores
        /// <summary>Source of Ore Images</summary>
        string OreImageSource = "Black32";
        /// <summary>Source of Product Images</summary>
        string ProductImageSource = "Black32";

        // ---Define Refinery Variables
        /// <summary>Array that holds refining products</summary>
        protected ProductType[] ProductTypes = new ProductType[8 + 7];
        /// <summary>Array that holds the different Ores and their data</summary>
        internal OreType[] OreTypes = new OreType[(16 * 3) + (1 * 12)];

        //--------------------------------------------------------------------------------------------
        // ---Define Ore Item Structures and Enums
        // ---Item Structures
        /// <summary>Structrue for storing Ore types</summary>
        public struct OreType
        {
            /// <summary>Name of the Ore</summary>
            public string Name;
            /// <summary>Root type of Ore</summary>
            public OreTypesRoot Root;
            /// <summary>Is this ore a master ore type?</summary>
            public bool IsMaster;
            /// <summary>Pysical size of one Ore unit (in m3)</summary>
            public Single Volume;
            /// <summary>String identifier for the Ore's icon</summary>
            public string Icon;
            /// <summary>Number of units needed to refine one batch</summary>
            public short UnitsToRefine;
            /// <summary>Skill Level for this particular Ore</summary>
            public int Skill;
            /// <summary>Array of output types for Ore</summary>
            public ArrayList Outputs;

            /// <summary>Constructor for OreType</summary>
            /// <param name="InputName">Ore Name</param>
            /// <param name="InputRoot">Ore Root</param>
            /// <param name="InputIsMaster">Is this a master Ore type?</param>
            /// <param name="InputVolume">Physical size of Ore (in m3)</param>
            /// <param name="InputIcon">Icon identifier string</param>
            /// <param name="InputUnitsToRefine">Number of units neede to refine one batch</param>
            public OreType(string InputName, OreTypesRoot InputRoot, bool InputIsMaster,
                           double InputVolume, string InputIcon, short InputUnitsToRefine)
            {
                this.Name = InputName;
                this.Root = InputRoot;
                this.IsMaster = InputIsMaster;
                this.Volume = (Single)InputVolume;
                this.Icon = InputIcon;
                this.UnitsToRefine = InputUnitsToRefine;
                this.Skill = 0;
                this.Outputs = new ArrayList();
            }
        }

        /// <summary>Structure to store refining products</summary>
        protected struct ProductType
        {
            public string Name;
            public string Icon;
            public short BaseOutput;

            public ProductType(ProductType Input, short BaseOutput)
            {
                this.Name = Input.Name;
                this.Icon = Input.Icon;
                this.BaseOutput = BaseOutput;
            }
        }

        /// <summary>Structure to store refining inputs</summary>
        public struct RefiningInput
        {
            public OreType Ore;
            public ulong AmountToRefine;
        }

        /// <summary>Structure to store refining outputs</summary>
        protected struct RefiningOutput
        {
            public ProductType Product;
            public ulong Total;
            public ulong Waste;
            public ulong BaseCut;
            public ulong Output;
        }

        // ---Type Enums
        /// <summary>Roots for refining products</summary>
        protected enum ProductTypesRoot
        {
            //---Rock Minerals
            Tritanium, Pyerite, Mexallon, Isogen, Nocxium, Zydrine, Megacyte, Morphite,
            //---Ice Products
            HeavyWater, LiquidOzone, StrontiumClathrates,
            OxygenIsotopes, HydrogenIsotopes, NitrogenIsotopes, HeliumIsotopes
        }

        /// <summary>Roots for all ore types</summary>
        public enum OreTypesRoot
        {
            //---Rock Ores             NOTE: Rearranging these changes the order they show up in the OreTypes array
            Veldspar, Scordite, Pyroxeres, Plagioclase, Omber, Kernite, Jaspet, Hedbergite,
            Hemorphite, Gneiss, DarkOchre, Crokite, Spudomain, Arkonor, Bistot, Mercoxit,
            //---Ice Ores
            IceOre
        }

        /// <summary>Sets the order of Ice Ore items</summary>
        protected enum IceOrder
        {
            //---Order of Ice Ores             NOTE: Rearranging these changes the order they show up in the OreTypes array
            GlareCrust, DarkGlitter, Gelidus, Krystallos, ClearIcicle, EnrichedClearIcicle,
            GlacialMass, SmoothGlacialMass, WhiteGlaze, PristineWhiteGlaze, BlueIce, ThickBlueIce
        }

        //--------------------------------------------------------------------------------------------
        // ---Initialize and load all data types and related resources
        /// <summary>Function used to initialize all ore calculator variables.</summary>
        private void InitializeData()
        {
            // ---Build Refine Product List

            //Minerals
            ProductTypes[(int)ProductTypesRoot.Tritanium].Name = ProductTypesRoot.Tritanium.ToString();
            ProductTypes[(int)ProductTypesRoot.Tritanium].Icon = "06_14";

            ProductTypes[(int)ProductTypesRoot.Pyerite].Name = ProductTypesRoot.Pyerite.ToString();
            ProductTypes[(int)ProductTypesRoot.Pyerite].Icon = "06_15";

            ProductTypes[(int)ProductTypesRoot.Mexallon].Name = ProductTypesRoot.Mexallon.ToString();
            ProductTypes[(int)ProductTypesRoot.Mexallon].Icon = "06_12";

            ProductTypes[(int)ProductTypesRoot.Isogen].Name = ProductTypesRoot.Isogen.ToString();
            ProductTypes[(int)ProductTypesRoot.Isogen].Icon = "06_16";

            ProductTypes[(int)ProductTypesRoot.Nocxium].Name = ProductTypesRoot.Nocxium.ToString();
            ProductTypes[(int)ProductTypesRoot.Nocxium].Icon = "11_09";

            ProductTypes[(int)ProductTypesRoot.Zydrine].Name = ProductTypesRoot.Zydrine.ToString();
            ProductTypes[(int)ProductTypesRoot.Zydrine].Icon = "11_11";

            ProductTypes[(int)ProductTypesRoot.Megacyte].Name = ProductTypesRoot.Megacyte.ToString();
            ProductTypes[(int)ProductTypesRoot.Megacyte].Icon = "11_10";

            ProductTypes[(int)ProductTypesRoot.Morphite].Name = ProductTypesRoot.Morphite.ToString();
            ProductTypes[(int)ProductTypesRoot.Morphite].Icon = "35_02";

            //Ice Products
            ProductTypes[(int)ProductTypesRoot.StrontiumClathrates].Name = "Strontium Clathrates";
            ProductTypes[(int)ProductTypesRoot.StrontiumClathrates].Icon = "51_10";

            ProductTypes[(int)ProductTypesRoot.LiquidOzone].Name = "Liquid Ozone";
            ProductTypes[(int)ProductTypesRoot.LiquidOzone].Icon = "51_11";

            ProductTypes[(int)ProductTypesRoot.HeavyWater].Name = "Heavy Water";
            ProductTypes[(int)ProductTypesRoot.HeavyWater].Icon = "51_12";

            ProductTypes[(int)ProductTypesRoot.HeliumIsotopes].Name = "Helium Isotopes";
            ProductTypes[(int)ProductTypesRoot.HeliumIsotopes].Icon = "51_13";

            ProductTypes[(int)ProductTypesRoot.HydrogenIsotopes].Name = "Hydrogen Isotopes";
            ProductTypes[(int)ProductTypesRoot.HydrogenIsotopes].Icon = "51_14";

            ProductTypes[(int)ProductTypesRoot.OxygenIsotopes].Name = "Oxygen Isotopes";
            ProductTypes[(int)ProductTypesRoot.OxygenIsotopes].Icon = "51_15";

            ProductTypes[(int)ProductTypesRoot.NitrogenIsotopes].Name = "Nitrogen Isotopes";
            ProductTypes[(int)ProductTypesRoot.NitrogenIsotopes].Icon = "51_16";

            // ---Build Product Image List
            foreach (ProductType Product in ProductTypes)
            {
                ilProducts.Images.Add(Product.Name, ResourceAccess.GetIcon(ProductImageSource, Product.Icon));
            }

            //--------------------------------------------------------------------------------------------
            // ---Build Rock Ore List

            //Plagioclase
            OreTypes[(int)OreTypesRoot.Plagioclase * 3] = new OreType("Plagioclase", OreTypesRoot.Plagioclase, true, 0.35, "24_02", 333);
            OreTypes[(int)OreTypesRoot.Plagioclase * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 256));
            OreTypes[(int)OreTypesRoot.Plagioclase * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 512));
            OreTypes[(int)OreTypesRoot.Plagioclase * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 256));

            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 1] = new OreType("Azure Plagioclase", OreTypesRoot.Plagioclase, false, 0.35, "24_02", 333);
            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 269));
            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 538));
            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 269));

            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 2] = new OreType("Rich Plagioclase", OreTypesRoot.Plagioclase, false, 0.35, "24_02", 333);
            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 282));
            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 563));
            OreTypes[(int)OreTypesRoot.Plagioclase * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 282));

            //Spudomain
            OreTypes[(int)OreTypesRoot.Spudomain * 3] = new OreType("Spodumain", OreTypesRoot.Spudomain, true, 16, "23_14", 250);
            OreTypes[(int)OreTypesRoot.Spudomain * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 700));
            OreTypes[(int)OreTypesRoot.Spudomain * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 140));
            OreTypes[(int)OreTypesRoot.Spudomain * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 140));

            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 1] = new OreType("Bright Spodumain", OreTypesRoot.Spudomain, false, 16, "23_14", 250);
            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 735));
            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 147));
            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 147));

            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 2] = new OreType("Gleaming Spodumain", OreTypesRoot.Spudomain, false, 16, "23_14", 250);
            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 770));
            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 154));
            OreTypes[(int)OreTypesRoot.Spudomain * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 154));

            //Kernite
            OreTypes[(int)OreTypesRoot.Kernite * 3] = new OreType("Kernite", OreTypesRoot.Kernite, true, 1.2, "23_12", 400);
            OreTypes[(int)OreTypesRoot.Kernite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 386));
            OreTypes[(int)OreTypesRoot.Kernite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 773));
            OreTypes[(int)OreTypesRoot.Kernite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 386));

            OreTypes[(int)OreTypesRoot.Kernite * 3 + 1] = new OreType("Luminous Kernite", OreTypesRoot.Kernite, false, 1.2, "23_12", 400);
            OreTypes[(int)OreTypesRoot.Kernite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 405));
            OreTypes[(int)OreTypesRoot.Kernite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 812));
            OreTypes[(int)OreTypesRoot.Kernite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 405));

            OreTypes[(int)OreTypesRoot.Kernite * 3 + 2] = new OreType("Fiery Kernite", OreTypesRoot.Kernite, false, 1.2, "23_12", 400);
            OreTypes[(int)OreTypesRoot.Kernite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 425));
            OreTypes[(int)OreTypesRoot.Kernite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 850));
            OreTypes[(int)OreTypesRoot.Kernite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 425));

            //Hedbergite
            OreTypes[(int)OreTypesRoot.Hedbergite * 3] = new OreType("Hedbergite", OreTypesRoot.Hedbergite, true, 3, "23_09", 500);
            OreTypes[(int)OreTypesRoot.Hedbergite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 708));
            OreTypes[(int)OreTypesRoot.Hedbergite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 354));
            OreTypes[(int)OreTypesRoot.Hedbergite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 33));

            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 1] = new OreType("Vitric Hedbergite", OreTypesRoot.Hedbergite, false, 3, "23_09", 500);
            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 743));
            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 372));
            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 34));

            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 2] = new OreType("Glazed Hedbergite", OreTypesRoot.Hedbergite, false, 3, "23_09", 500);
            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 779));
            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 389));
            OreTypes[(int)OreTypesRoot.Hedbergite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 35));

            //Arkonor
            OreTypes[(int)OreTypesRoot.Arkonor * 3] = new OreType("Arkonor", OreTypesRoot.Arkonor, true, 16, "23_05", 200);
            OreTypes[(int)OreTypesRoot.Arkonor * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 300));
            OreTypes[(int)OreTypesRoot.Arkonor * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 166));
            OreTypes[(int)OreTypesRoot.Arkonor * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 333));

            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 1] = new OreType("Crimson Arkonor", OreTypesRoot.Arkonor, false, 16, "23_05", 200);
            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 315));
            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 174));
            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 350));

            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 2] = new OreType("Prime Arkonor", OreTypesRoot.Arkonor, false, 16, "23_05", 200);
            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 330));
            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 183));
            OreTypes[(int)OreTypesRoot.Arkonor * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 366));

            //Bistot
            OreTypes[(int)OreTypesRoot.Bistot * 3] = new OreType("Bistot", OreTypesRoot.Bistot, true, 16, "23_06", 200);
            OreTypes[(int)OreTypesRoot.Bistot * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 170));
            OreTypes[(int)OreTypesRoot.Bistot * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 341));
            OreTypes[(int)OreTypesRoot.Bistot * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 170));

            OreTypes[(int)OreTypesRoot.Bistot * 3 + 1] = new OreType("Triclinic Bistot", OreTypesRoot.Bistot, false, 16, "23_06", 200);
            OreTypes[(int)OreTypesRoot.Bistot * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 179));
            OreTypes[(int)OreTypesRoot.Bistot * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 358));
            OreTypes[(int)OreTypesRoot.Bistot * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 179));

            OreTypes[(int)OreTypesRoot.Bistot * 3 + 2] = new OreType("Monoclinic Bistot", OreTypesRoot.Bistot, false, 16, "23_06", 200);
            OreTypes[(int)OreTypesRoot.Bistot * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 187));
            OreTypes[(int)OreTypesRoot.Bistot * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 375));
            OreTypes[(int)OreTypesRoot.Bistot * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Megacyte], 187));

            //Pyroxeres
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3] = new OreType("Pyroxeres", OreTypesRoot.Pyroxeres, true, 0.3, "23_16", 333);
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 844));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 59));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 120));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 11));

            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 1] = new OreType("Solid Pyroxeres", OreTypesRoot.Pyroxeres, false, 0.3, "23_16", 333);
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 886));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 62));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 126));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 12));

            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 2] = new OreType("Viscous Pyroxeres", OreTypesRoot.Pyroxeres, false, 0.3, "23_16", 333);
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 928));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 65));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 132));
            OreTypes[(int)OreTypesRoot.Pyroxeres * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 12));

            //Crokite
            OreTypes[(int)OreTypesRoot.Crokite * 3] = new OreType("Crokite", OreTypesRoot.Crokite, true, 16, "23_07", 250);
            OreTypes[(int)OreTypesRoot.Crokite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 331));
            OreTypes[(int)OreTypesRoot.Crokite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 331));
            OreTypes[(int)OreTypesRoot.Crokite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 663));

            OreTypes[(int)OreTypesRoot.Crokite * 3 + 1] = new OreType("Sharp Crokite", OreTypesRoot.Crokite, false, 16, "23_07", 250);
            OreTypes[(int)OreTypesRoot.Crokite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 348));
            OreTypes[(int)OreTypesRoot.Crokite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 348));
            OreTypes[(int)OreTypesRoot.Crokite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 696));

            OreTypes[(int)OreTypesRoot.Crokite * 3 + 2] = new OreType("Crystaline Crokite", OreTypesRoot.Crokite, false, 16, "23_07", 250);
            OreTypes[(int)OreTypesRoot.Crokite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 364));
            OreTypes[(int)OreTypesRoot.Crokite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 364));
            OreTypes[(int)OreTypesRoot.Crokite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 729));

            //Jaspet
            OreTypes[(int)OreTypesRoot.Jaspet * 3] = new OreType("Jaspet", OreTypesRoot.Jaspet, true, 2, "23_11", 500);
            OreTypes[(int)OreTypesRoot.Jaspet * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 259));
            OreTypes[(int)OreTypesRoot.Jaspet * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 259));
            OreTypes[(int)OreTypesRoot.Jaspet * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 518));
            OreTypes[(int)OreTypesRoot.Jaspet * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 259));
            OreTypes[(int)OreTypesRoot.Jaspet * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 8));

            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 1] = new OreType("Pure Jaspet", OreTypesRoot.Jaspet, false, 2, "23_11", 500);
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 272));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 272));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 544));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 272));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 8));

            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 2] = new OreType("Pristine Jaspte", OreTypesRoot.Jaspet, false, 2, "23_11", 500);
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 285));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 285));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 570));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 285));
            OreTypes[(int)OreTypesRoot.Jaspet * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 9));

            //Omber
            OreTypes[(int)OreTypesRoot.Omber * 3] = new OreType("Omber", OreTypesRoot.Omber, true, 0.6, "23_13", 500);
            OreTypes[(int)OreTypesRoot.Omber * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 307));
            OreTypes[(int)OreTypesRoot.Omber * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 123));
            OreTypes[(int)OreTypesRoot.Omber * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 307));

            OreTypes[(int)OreTypesRoot.Omber * 3 + 1] = new OreType("Silvery Omber", OreTypesRoot.Omber, false, 0.6, "23_13", 500);
            OreTypes[(int)OreTypesRoot.Omber * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 322));
            OreTypes[(int)OreTypesRoot.Omber * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 129));
            OreTypes[(int)OreTypesRoot.Omber * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 322));

            OreTypes[(int)OreTypesRoot.Omber * 3 + 2] = new OreType("Golden Omber", OreTypesRoot.Omber, false, 0.6, "23_13", 500);
            OreTypes[(int)OreTypesRoot.Omber * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 338));
            OreTypes[(int)OreTypesRoot.Omber * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 135));
            OreTypes[(int)OreTypesRoot.Omber * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 338));

            //Scordite
            OreTypes[(int)OreTypesRoot.Scordite * 3] = new OreType("Scordite", OreTypesRoot.Scordite, true, 0.15, "23_15", 333);
            OreTypes[(int)OreTypesRoot.Scordite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 833));
            OreTypes[(int)OreTypesRoot.Scordite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 416));

            OreTypes[(int)OreTypesRoot.Scordite * 3 + 1] = new OreType("Condensed Scordite", OreTypesRoot.Scordite, false, 0.15, "23_15", 333);
            OreTypes[(int)OreTypesRoot.Scordite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 875));
            OreTypes[(int)OreTypesRoot.Scordite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 437));

            OreTypes[(int)OreTypesRoot.Scordite * 3 + 2] = new OreType("Massive Scordite", OreTypesRoot.Scordite, false, 0.15, "23_15", 333);
            OreTypes[(int)OreTypesRoot.Scordite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 916));
            OreTypes[(int)OreTypesRoot.Scordite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Pyerite], 458));

            //Gneiss
            OreTypes[(int)OreTypesRoot.Gneiss * 3] = new OreType("Gneiss", OreTypesRoot.Gneiss, true, 5, "25_01", 400);
            OreTypes[(int)OreTypesRoot.Gneiss * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 171));
            OreTypes[(int)OreTypesRoot.Gneiss * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 171));
            OreTypes[(int)OreTypesRoot.Gneiss * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 343));
            OreTypes[(int)OreTypesRoot.Gneiss * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 171));

            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 1] = new OreType("Iridescent Gneiss", OreTypesRoot.Gneiss, false, 5, "25_01", 400);
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 180));
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 180));
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 360));
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 180));

            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 2] = new OreType("Prismatic Gneiss", OreTypesRoot.Gneiss, false, 5, "25_01", 400);
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 188));
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Mexallon], 188));
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 377));
            OreTypes[(int)OreTypesRoot.Gneiss * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 188));

            //Veldspar
            OreTypes[(int)OreTypesRoot.Veldspar * 3] = new OreType("Veldspar", OreTypesRoot.Veldspar, true, 0.1, "24_01", 333);
            OreTypes[(int)OreTypesRoot.Veldspar * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 1000));

            OreTypes[(int)OreTypesRoot.Veldspar * 3 + 1] = new OreType("Concentrated Veldspar", OreTypesRoot.Veldspar, false, 0.1, "24_01", 333);
            OreTypes[(int)OreTypesRoot.Veldspar * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 1050));

            OreTypes[(int)OreTypesRoot.Veldspar * 3 + 2] = new OreType("Dense Veldspar", OreTypesRoot.Veldspar, false, 0.1, "24_01", 333);
            OreTypes[(int)OreTypesRoot.Veldspar * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 1100));

            //Hemorphite
            OreTypes[(int)OreTypesRoot.Hemorphite * 3] = new OreType("Hemorphite", OreTypesRoot.Hemorphite, true, 3, "23_10", 500);
            OreTypes[(int)OreTypesRoot.Hemorphite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 212));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 212));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 424));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 28));

            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 1] = new OreType("Vivid Hedbergite", OreTypesRoot.Hemorphite, false, 3, "23_10", 500);
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 223));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 223));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 445));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 29));

            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 2] = new OreType("Radiant Hemorphite", OreTypesRoot.Hemorphite, false, 3, "23_10", 500);
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 233));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Isogen], 233));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 466));
            OreTypes[(int)OreTypesRoot.Hemorphite * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 31));

            //DarkOchre
            OreTypes[(int)OreTypesRoot.DarkOchre * 3] = new OreType("Dark Ochre", OreTypesRoot.DarkOchre, true, 8, "23_08", 400);
            OreTypes[(int)OreTypesRoot.DarkOchre * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 250));
            OreTypes[(int)OreTypesRoot.DarkOchre * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 500));
            OreTypes[(int)OreTypesRoot.DarkOchre * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 250));

            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 1] = new OreType("Onyx Ochre", OreTypesRoot.DarkOchre, false, 8, "23_08", 400);
            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 263));
            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 525));
            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 263));

            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 2] = new OreType("Obsidian Ochre", OreTypesRoot.DarkOchre, false, 8, "23_08", 400);
            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Tritanium], 275));
            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Nocxium], 550));
            OreTypes[(int)OreTypesRoot.DarkOchre * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Zydrine], 275));

            //Mercoxit
            OreTypes[(int)OreTypesRoot.Mercoxit * 3] = new OreType("Mercoxit", OreTypesRoot.Mercoxit, true, 40, "35_11", 250);
            OreTypes[(int)OreTypesRoot.Mercoxit * 3].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Morphite], 530));

            OreTypes[(int)OreTypesRoot.Mercoxit * 3 + 1] = new OreType("Magma Mercoxit", OreTypesRoot.Mercoxit, false, 40, "35_11", 250);
            OreTypes[(int)OreTypesRoot.Mercoxit * 3 + 1].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Morphite], 557));

            OreTypes[(int)OreTypesRoot.Mercoxit * 3 + 2] = new OreType("Vitreous Mercoxit", OreTypesRoot.Mercoxit, false, 40, "35_11", 250);
            OreTypes[(int)OreTypesRoot.Mercoxit * 3 + 2].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.Morphite], 583));

            //--------------------------------------------------------------------------------------------
            //---Build Ice Ore List

            //Glare Crust
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlareCrust] = new OreType("Glare Crust", OreTypesRoot.IceOre, false, 1000, "51_01", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlareCrust].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],1000));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlareCrust].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],500));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlareCrust].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],25));

            //Clear Icicle
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ClearIcicle] = new OreType("Clear Icicle", OreTypesRoot.IceOre, false, 1000, "51_02", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],50));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],25));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeliumIsotopes],300));

            //Enriched Clear Icicle
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.EnrichedClearIcicle] = new OreType("Enriched Clear Icicle", OreTypesRoot.IceOre, false, 1000, "51_02", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.EnrichedClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],75));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.EnrichedClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],40));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.EnrichedClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.EnrichedClearIcicle].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeliumIsotopes],350));

            //Dark Glitter
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.DarkGlitter] = new OreType("Dark Glitter", OreTypesRoot.IceOre, false, 1000, "51_03", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.DarkGlitter].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],500));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.DarkGlitter].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],1000));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.DarkGlitter].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],50));

            //Glacial Mass
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlacialMass] = new OreType("Glacial Mass", OreTypesRoot.IceOre, false, 1000, "51_04", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],50));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],25));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.GlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HydrogenIsotopes],300));

            //Smooth Glacial Mass
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.SmoothGlacialMass] = new OreType("Smooth Glacial Mass", OreTypesRoot.IceOre, false, 1000, "51_04", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.SmoothGlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],75));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.SmoothGlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],40));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.SmoothGlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.SmoothGlacialMass].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HydrogenIsotopes],350));

            //Blue Ice
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.BlueIce] = new OreType("Blue Ice", OreTypesRoot.IceOre, false, 1000, "51_05", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.BlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],50));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.BlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],25));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.BlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.BlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.OxygenIsotopes],300));

            //Thick Blue Ice
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ThickBlueIce] = new OreType("Thick Blue Ice", OreTypesRoot.IceOre, false, 1000, "51_05", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ThickBlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],75));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ThickBlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],40));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ThickBlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.ThickBlueIce].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.OxygenIsotopes],350));

            //Gelidus
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Gelidus] = new OreType("Gelidus", OreTypesRoot.IceOre, false, 1000, "51_06", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Gelidus].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],250));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Gelidus].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],500));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Gelidus].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],75));

            //White Glaze
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.WhiteGlaze] = new OreType("White Glaze", OreTypesRoot.IceOre, false, 1000, "51_08", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.WhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],50));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.WhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],25));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.WhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.WhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.NitrogenIsotopes],300));

            //Pristine White Glaze
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.PristineWhiteGlaze] = new OreType("Pristine White Glaze", OreTypesRoot.IceOre, false, 1000, "51_08", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.PristineWhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],75));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.PristineWhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.LiquidOzone],40));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.PristineWhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.StrontiumClathrates],1));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.PristineWhiteGlaze].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.NitrogenIsotopes],350));

            //Krystallos
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Krystallos] = new OreType("Krystallos", OreTypesRoot.IceOre, false, 1000, "51_09", 1);
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Krystallos].Outputs.Add(new ProductType( ProductTypes[(int)ProductTypesRoot.HeavyWater],100));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Krystallos].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.LiquidOzone], 250));
            OreTypes[(int)OreTypesRoot.IceOre * 3 + (int)IceOrder.Krystallos].Outputs.Add(new ProductType(ProductTypes[(int)ProductTypesRoot.StrontiumClathrates], 100));

            // ---Build Ore Image List
            foreach (OreType Ore in OreTypes)
            {
                ilOres.Images.Add(Ore.Name, ResourceAccess.GetIcon(OreImageSource, Ore.Icon));
            }
        }
    }
}