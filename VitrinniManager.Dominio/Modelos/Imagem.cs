using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbImagemProduto", Schema = "vitrinni")]
    public class Imagem
    {
        protected Imagem() { }

        [Key]
        public int IdProdutoImagem { get; set; }

        public string nome { get; set; }

        public int? principal { get; set; }

        public bool ativa { get; set; }

        public DateTime? dataCadastramento { get; set; }

        [ForeignKey("Produto")]
        public int idProduto { get; set; }

        public virtual Produto Produto { get; set; }

        //public void ValidaImagem(Imagem img)
        //{
        //    AssertionConcern.AssertArgumentNotNull(img.nome, "Não foi possível definir um nome para imagem, tente novamente.");
        //    AssertionConcern.AssertArgumentNotNull(img.ativa, "E obrigatório definir uma imagem principal.");
        //}

        public static void Comprimir(Stream sourcePath, string targetPath)
        {
            try
            {
                using (var image = System.Drawing.Image.FromStream(sourcePath))
                {
                    float maxHeight = 900.0f;
                    float maxWidth = 900.0f;
                    int newWidth;
                    int newHeight;
                    string extension;
                    Bitmap originalBMP = new Bitmap(sourcePath);
                    int originalWidth = originalBMP.Width;
                    int originalHeight = originalBMP.Height;

                    if (originalWidth > maxWidth || originalHeight > maxHeight)
                    {
                        // To preserve the aspect ratio  
                        float ratioX = (float)maxWidth / (float)originalWidth;
                        float ratioY = (float)maxHeight / (float)originalHeight;
                        float ratio = Math.Min(ratioX, ratioY);
                        newWidth = (int)(originalWidth * ratio);
                        newHeight = (int)(originalHeight * ratio);
                    }
                    else
                    {
                        newWidth = (int)originalWidth;
                        newHeight = (int)originalHeight;

                    }
                    Bitmap bitMAP1 = new Bitmap(originalBMP, newWidth, newHeight);
                    Graphics imgGraph = Graphics.FromImage(bitMAP1);
                    extension = Path.GetExtension(targetPath);
                    if (extension == ".png" || extension == ".gif")
                    {
                        imgGraph.SmoothingMode = SmoothingMode.HighSpeed;
                        imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        imgGraph.CompositingQuality = CompositingQuality.HighSpeed;
                        imgGraph.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                 
                        bitMAP1.Save(targetPath, image.RawFormat);

                        bitMAP1.Dispose();
                        imgGraph.Dispose();
                        originalBMP.Dispose();
                    }
                    else if (extension == ".jpg")
                    {

                        imgGraph.SmoothingMode = SmoothingMode.AntiAlias;
                        imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        imgGraph.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        Encoder myEncoder = Encoder.Quality;
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);
                        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 85L);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        bitMAP1.Save(targetPath, jpgEncoder, myEncoderParameters);

                        bitMAP1.Dispose();
                        imgGraph.Dispose();
                        originalBMP.Dispose();

                    }


                }

            }
            catch (Exception ex)
            {
                string erro = ex.Message.ToString();
                throw;

            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static string CriarPasta(int idLoja)
        {
            var path = HttpContext.Current.Server.MapPath("~/Uploads/" + idLoja.ToString());
            var retorno = string.Empty;

            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    retorno = HttpContext.Current.Server.MapPath("~/Uploads/" + idLoja.ToString()).ToString();
                }
                catch (Exception)
                {

                    retorno = null;
                }
            }
            else
            {
                retorno = HttpContext.Current.Server.MapPath("~/Uploads/" + idLoja.ToString()).ToString();
            }

            return retorno;
        }
    }
}
