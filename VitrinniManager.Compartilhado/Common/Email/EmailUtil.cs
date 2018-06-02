using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VitrinniManager.Compartilhado.Common.Email
{
    public class EmailUtil
    {
        //private string RemetenteEmail => ConfigurationManager.AppSettings["RemetenteEmail"];
        //private string HostEmail => ConfigurationManager.AppSettings["HostEmail"];
        //private string PortaEmail => ConfigurationManager.AppSettings["PortaEmail"];


        private string RemetenteEmail => "appweb@cebraspe.org.br";
        private string HostEmail => "smtp.cebraspe.org.br";
        private string PortaEmail => "25";

        public void EnviarEmailAsync(string destinatario, string assunto, string mensagem)
        {
            using (var email = new MailMessage())
            {
                email.To.Add(destinatario);
                email.Subject = assunto;
                email.From = new MailAddress(this.RemetenteEmail);
                email.IsBodyHtml = true;
                email.Body = mensagem;

                using (var smtp = new SmtpClient())
                {
                    smtp.Timeout = 5000;
                    smtp.Host = this.HostEmail;
                    smtp.Port = int.Parse(this.PortaEmail);

                    smtp.Send(email);
                }
            }
        }

        public static string MensagemEmail_RedefinirSenha(string usuario, string link)
        {
            return @"<html>
                        <body>
                            <div style='font-family:Calibri;'>
                                <h2 style='color:#ff6a00;'>
                                Alteração de senha
                                </h2>

                                <p>Prezado(a) " + usuario + @",</p>
                                
                                <span style='text-decoration:none;'>
                                    Clique no <i>link</i> abaixo para confirmar sua senha ou copie e cole o <i>link</i> no seu navegador. <br />
                                </span>
                                   
                                <a href='" + link + @"' style='text-decoration:none;'>" + link + @" </a>

                                <br />                    
                                <br />

                                <strong>Atenção:</strong> Caso haja algum impedimento no acesso ao <i>link</i>, por favor contatar o administrador do sistema.
                                 
                                <br />
                                <br />
                                <br />
                                 
                                Atenciosamente,
                                <br />
                                <p>&copy; " + DateTime.Now.Year + @" - Vitrinni</p>
                            </div>
                        </body>
                     </html>";
        }
    }
}
