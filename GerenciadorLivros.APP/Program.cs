using GerenciadorLivros.APP;

List<Book> books = new List<Book>();
List<User> users = new List<User>();
bool programaExecutando = true;

while (programaExecutando)
{
    bool existeId = false;
    Menu();

    Console.ReadLine();

    void Menu()
    {
        int opcao = 0;

        do
        {            
            Console.Clear();
            Console.WriteLine("Sistema de Gerenciamento de Livros");
            Console.WriteLine();
            Console.WriteLine("Opção 1 - Cadastrar livro ");
            Console.WriteLine("Opção 2 - Consultar todos os livros ");
            Console.WriteLine("Opção 3 - Consultar um livro ");
            Console.WriteLine("Opção 4 - Remover um livro ");
            Console.WriteLine("Opção 5 - Cadastrar usuário ");
            Console.WriteLine("Opção 6 - Consultar usuários ");
            Console.WriteLine("Opção 9 - Sair do sistema ");
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarLivro();
                    break;
                case 2:
                    ConsultarLivros();
                    break;
                case 3:
                    ConsultarUmLivro();
                    break;
                case 4:
                    RemoverLivro();
                    break;
                case 5:
                    CadastrarUsuario();
                    break;
                case 6:
                    ConsultarUsuarios();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("Obrigado por Utilizar o Sistema!");
                    programaExecutando = false;
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    Menu();
                    break;
            }
            
        } while (opcao != 9);
    }

    void CadastrarLivro()
    {
        Book livro = new Book();           

        Console.Write("Informe o ID: ");
        livro.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Informe o título: ");
        livro.Title = Console.ReadLine();
        Console.Write("Informe o autor: ");
        livro.Author = Console.ReadLine();
        Console.Write("Informe o ISBN: ");
        livro.ISBN = Console.ReadLine();
        Console.Write("Informe o ano de publicação: ");
        livro.YearPublicacion = Convert.ToInt32(Console.ReadLine());

        if (ValidarLivro(livro))
        {            
            books.Add(livro);
            Console.WriteLine("Livro cadastrado com sucesso");
        }
        Console.ReadLine();
        Menu();
    }
        
    void ConsultarLivros()
    {
        foreach (Book liv in books)
        {
            Console.WriteLine($"Id: {liv.Id} - Titulo: {liv.Title} - Autor: {liv.Author} - ISBN: {liv.ISBN} - Ano da publicação: {liv.YearPublicacion}");
        }
        Console.ReadLine();
        Menu();
    }

    void ConsultarUmLivro()
    {
        Console.Write("Informe o ID para consulta: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Book liv in books)
        {
            if (liv.Id == id)
            {
                Console.WriteLine($"ID: {liv.Id} ");
                Console.WriteLine($"Título: {liv.Title}");                
                Console.WriteLine($"Informe o autor: {liv.Author}");                
                Console.WriteLine($"Informe o ISBN: {liv.ISBN}");                
                Console.WriteLine($"Informe o ano de publicação: {liv.YearPublicacion}");                
            } 
        }
        Console.ReadLine();
        Menu();
    }

    void RemoverLivro()
    {
        Console.Write("Informe o ID para remover: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var index = 0;

        foreach (Book liv in books)
        {            
            if (liv.Id == id)
            {
                books.RemoveAt(index);
                Console.WriteLine("Livro removido com sucesso");
                break;
            }
            index++;
        }
        Console.ReadLine();
        Menu();
    }

    bool ValidarLivro(Book livro)
    {
        foreach (Book liv in books)
        {
            if (liv.Id == livro.Id)
            {
                Console.WriteLine("Id já existe na lista");
                return false;
            }
        }
        if (string.IsNullOrEmpty(livro.Title))
        {
            Console.WriteLine("Título não informado");
            return false;
        }
        if (string.IsNullOrEmpty(livro.Author))
        {
            Console.WriteLine("Autor não informado");
            return false;
        }
        if (string.IsNullOrEmpty(livro.ISBN))
        {
            Console.WriteLine("ISBN não informado");
            return false;
        }
        if (livro.YearPublicacion == 0)
        {
            Console.WriteLine("Ano de publicação não informado");
            return false;
        }
        return true;
    }

    void CadastrarUsuario()
    {
        User usuario = new User();

        Console.Write("Informe o ID: ");
        usuario.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Informe o nome do usuario: ");
        usuario.Name = Console.ReadLine();
        Console.Write("Informe o e-mail: ");
        usuario.Email = Console.ReadLine();

        if (ValidarUsuario(usuario))
        {
            users.Add(usuario);
        }
        Console.ReadLine();
        Menu();
    }

    void ConsultarUsuarios()
    {
        foreach (User usu in users)
        {
            Console.WriteLine($"Id: {usu.Id} - Titulo: {usu.Name} - Autor: {usu.Email}");
        }
        Console.ReadLine();
        Menu();
    }

    bool ValidarUsuario(User usuario)
    {
        foreach (User usu in users)
        {
            if (usu.Id == usuario.Id)
            {
                Console.WriteLine("Id já existe na lista");
                return false;
            }
        }
        if (string.IsNullOrEmpty(usuario.Name))
        {
            Console.WriteLine("Nome não informado");
            return false;
        }
        if (string.IsNullOrEmpty(usuario.Email))
        {
            Console.WriteLine("E-mail não informado");
            return false;
        }
        return true;
    }
}

