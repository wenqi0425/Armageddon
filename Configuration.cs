using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Armageddon
{
    public class Configuration
    {
        public const string CONFIG_FILE = "GameConfigration.xml";
        public static int MaxWidth { get; set; }
        public static int MaxHeight { get; set; }
        public static int WorldTreeWidth { get; set; }
        public static int WorldTreeHeight { get; set; }
        public static int TreePosistionX { get; set; }
        public static int TreePosistionY { get; set; }
        public static double TreeLifeRatio { get; set; }
        public static double TreeDefenceRatio { get; set; }
        public static double TreeAttackRatio { get; set; }
        public static double StoneLifeRatio { get; set; }
        public static double StoneDefenceRatio { get; set; }
        public static double StoneAttackRatio { get; set; }
        public static double FlowerLifeRatio { get; set; }
        public static double FlowerDefenceRatio { get; set; }
        public static double FlowerAttackRatio { get; set; }

        public static void ReadConfiguration()
        {
            // Configuration conf = new Configuration();

            XmlDocument configDoc = new();
            //configDoc.Load("C:\\GameConfigration.xml" + @"\" + CONFIG_FILE);
            // configDoc.Load("C://Users/wenqi/Desktop/4th Semester/1.ASW/Assignment/Armageddon/GameConfigration.xml" + @"\" + CONFIG_FILE);
            configDoc.Load(/*"C:/Users/wenqi/Desktop/Assignment/Armageddon/GameConfigration.xml" + @"\" +*/ CONFIG_FILE);

            XmlNode MaxWidthNode = configDoc.DocumentElement.SelectSingleNode("MaxWidth");
            if (MaxWidthNode != null)
            {
                String str = MaxWidthNode.InnerText.Trim();
                MaxWidth = Convert.ToInt32(str);
            }

            XmlNode MaxHeightNode = configDoc.DocumentElement.SelectSingleNode("MaxHeight");
            if (MaxHeightNode != null)
            {
                String str = MaxHeightNode.InnerText.Trim();
                MaxHeight = Convert.ToInt32(str);
            }

            XmlNode WorldTreeWidthNode = configDoc.DocumentElement.SelectSingleNode("WorldTreeWidth");
            if (WorldTreeWidthNode != null)
            {
                String str = WorldTreeWidthNode.InnerText.Trim();
                WorldTreeWidth = Convert.ToInt32(str);
            }

            XmlNode WorldTreeHeightNode = configDoc.DocumentElement.SelectSingleNode("WorldTreeHeight");
            if (WorldTreeHeightNode != null)
            {
                String str = WorldTreeHeightNode.InnerText.Trim();
                WorldTreeHeight = Convert.ToInt32(str);
            }

            XmlNode TreePosistionXNode = configDoc.DocumentElement.SelectSingleNode("TreePosistionX");
            if (TreePosistionXNode != null)
            {
                String str = TreePosistionXNode.InnerText.Trim();
                TreePosistionX = Convert.ToInt32(str);
            }

            XmlNode TreePosistionYNode = configDoc.DocumentElement.SelectSingleNode("TreePosistionY");
            if (TreePosistionYNode != null)
            {
                String str = TreePosistionYNode.InnerText.Trim();
                TreePosistionY = Convert.ToInt32(str);
            }

            XmlNode TreeLifeRatioNode = configDoc.DocumentElement.SelectSingleNode("TreeLifeRatio");
            if (TreeLifeRatioNode != null)
            {
                String str = TreeLifeRatioNode.InnerText.Trim();
                TreeLifeRatio = Convert.ToDouble(str);
            }
            
            XmlNode TreeDefenceRatioNode = configDoc.DocumentElement.SelectSingleNode("TreeDefenceRatio");
            if (TreeDefenceRatioNode != null)
            {
                String str = TreeDefenceRatioNode.InnerText.Trim();
                TreeDefenceRatio = Convert.ToDouble(str);
            }

            XmlNode TreeAttackRatioNode = configDoc.DocumentElement.SelectSingleNode("TreeAttackRatio");
            if (TreeAttackRatioNode != null)
            {
                String str = TreeAttackRatioNode.InnerText.Trim();
                TreeAttackRatio = Convert.ToDouble(str);
            }
            
            XmlNode StoneLifeRatioNode = configDoc.DocumentElement.SelectSingleNode("StoneLifeRatio");
            if (StoneLifeRatioNode != null)
            {
                String str = StoneLifeRatioNode.InnerText.Trim();
                StoneLifeRatio = Convert.ToDouble(str);
            }

            XmlNode StoneDefenceRatioNode = configDoc.DocumentElement.SelectSingleNode("StoneDefenceRatio");
            if (StoneDefenceRatioNode != null)
            {
                String str = StoneDefenceRatioNode.InnerText.Trim();
                StoneDefenceRatio = Convert.ToDouble(str);
            }

            XmlNode StoneAttackRatioNode = configDoc.DocumentElement.SelectSingleNode("StoneAttackRatio");
            if (StoneAttackRatioNode != null)
            {
                String str = StoneAttackRatioNode.InnerText.Trim();
                StoneAttackRatio = Convert.ToDouble(str);
            }

            // 0.2 has been converted to 2. Don't know why. 
            XmlNode FlowerLifeRatioNode = configDoc.DocumentElement.SelectSingleNode("FlowerLifeRatio");
            if (FlowerLifeRatioNode != null)
            {
                String str = FlowerLifeRatioNode.InnerText.Trim();
                FlowerLifeRatio = Convert.ToDouble(str);
            }



            XmlNode FlowerDefenceRatioNode = configDoc.DocumentElement.SelectSingleNode("FlowerDefenceRatio");
            if (FlowerDefenceRatioNode != null)
            {
                String str = FlowerDefenceRatioNode.InnerText.Trim();
                FlowerDefenceRatio = Convert.ToDouble(str);
            }

            XmlNode FlowerAttackRatioNode = configDoc.DocumentElement.SelectSingleNode("FlowerAttackRatio");
            if (FlowerAttackRatioNode != null)
            {
                String str = FlowerAttackRatioNode.InnerText.Trim();
                FlowerAttackRatio = Convert.ToDouble(str);
            }
        }
    }
}
