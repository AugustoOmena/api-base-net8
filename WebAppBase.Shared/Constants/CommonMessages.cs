namespace WebAppBase.Shared.Constants;

    public class CommonMessages
    {
        public static readonly string InvalidCredentials = "E-mail e/ou senha inválido(s)";

        public static readonly string UnprocessableEntity = "Solicitação inválida. Verifique os dados enviados e tente novamente.";
        
        public static readonly string InternalServerError = "Internal Server Error";

        public static readonly string UserNotFount = "Usuário não foi encontrado";

        public static readonly string ProblemSavindData = "Não foi possível salvar os dados no momento";
        
        public static readonly string InvalidProfile = "Ação não permitida para o perfil do usuário informado.";
        
        public static readonly string Unauthorized = "Unauthorized";

        public static readonly string Forbidden = "Forbidden";

        public static readonly string NotActiveProfile = "O perfil do usuário informado está inativo.";
        
        public static readonly string InvalidRefreshToken = "Sua sessão expirou, por favor faça o login novamente.";

        public static string BuiltRequiredMessageError(string propertyName) => $"{propertyName} é requerido";

        public static string BuiltMaxLenghMessageError(string propertyName,
            int maxLength) => $"{propertyName} deve conter no máximo {maxLength} caracteres";

        public static string BuiltMinAndMaxLenghMessageError(string propertyName,
            int minLength, int maxLength) => $"{propertyName} deve conter no mínimo {minLength} e no máximo {maxLength} caracteres";
    }