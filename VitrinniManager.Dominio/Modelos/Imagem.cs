using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using VitrinniManager.Common.Validacao;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbImagemProduto", Schema = "vitrinni")]
    public class Imagem
    {
        protected Imagem() { }

        public Imagem(int _idproduto, int _idLoja, string _base64)
        {
            this.nome = Guid.NewGuid().ToString() + ".jpg";
            this.principal = 0;
            this.ativa = true;
            this.dataCadastramento = DateTime.Now;
            this.idProduto = _idproduto;

            if (_idLoja != 0)
            {
                this.diretorio = CriarPasta(_idLoja);//cria o diretoria da loja se não existir
                this.base64 = Convert.FromBase64String(_base64 == null ? "" : _base64);//converte a string para um array de bytes
                this.pathCompleta = Path.Combine(diretorio, nome);//retorna o caminho completo da imagem
            }

        }

        public Imagem(int _idimagem, string _nome, int _idProduto, int _principal, bool _ativa, int _idLoja)
        {
            this.IdProdutoImagem = _idimagem;
            this.nome = _nome;
            this.principal = _principal;
            this.ativa = _ativa;
            this.idProduto = _idProduto;
            this.diretorio = CriarPasta(_idLoja);
            this.pathCompleta = Path.Combine(diretorio, nome);//retorna o caminho completo da imagem
            this.base64Retorno = "data:image/jpg;base64," + ConvertBase64(pathCompleta);
        }

        [Key]
        public int IdProdutoImagem { get; set; }

        public string nome { get; set; }

        public int? principal { get; set; }

        public bool ativa { get; set; }

        public DateTime? dataCadastramento { get; set; }

        [ForeignKey("Produto")]
        public int idProduto { get; set; }

        [NotMapped]
        public string diretorio { get; set; }

        [NotMapped]
        public byte[] base64 { get; set; }

        [NotMapped]
        public string base64Retorno { get; set; }

        [NotMapped]
        public string pathCompleta { get; set; }

        public virtual Produto Produto { get; set; }

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
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar a imagem.");
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
                    retorno = path;
                }
                catch (Exception)
                {

                    retorno = null;
                }
            }
            else
            {
                retorno = path;
            }

            return retorno;
        }

        public static string ConvertBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
