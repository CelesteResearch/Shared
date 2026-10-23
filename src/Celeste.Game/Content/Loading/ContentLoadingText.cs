namespace Celeste.Game.Content.Loading
{
    internal sealed class ContentLoadingText
    {
        public readonly string Title, Continue, Content, Audio, Size, Files;
        public readonly string Rate, Estimating, Processing, Ready;

        private ContentLoadingText(string title, string continuation, string content, string audio,
            string size, string files, string rate = "Read rate: ~{0}/s  |  Time left: ~{1}",
            string estimating = "Estimating read time", string processing = "Processing resources",
            string ready = "Resources ready")
        {
            Title = title;
            Continue = continuation;
            Content = content;
            Audio = audio;
            Size = size;
            Files = files;
            Rate = rate;
            Estimating = estimating;
            Processing = processing;
            Ready = ready;
        }

        private static readonly ContentLoadingText English = new("Loading", "Your adventure will continue when ready",
            "Game resources", "Music and sound", "{0}%   {1} / {2} MiB", "{0} / {1} files ready");

        private static readonly ContentLoadingText Chinese = new("正在加载", "准备完成后会自动继续",
            "正在读取游戏资源", "正在读取音乐与音效", "{0}%   {1} / {2} MiB", "已准备 {0} / {1} 个文件",
            "读取速度：约 {0}/s  |  还需约 {1}", "正在计算所需时间", "正在处理资源", "资源已准备");

        private static readonly ContentLoadingText French = new("Chargement",
            "L’aventure reprendra dès que tout sera prêt",
            "Ressources du jeu", "Musique et sons", "{0}%   {1} / {2} MiB", "{0} / {1} fichiers prêts",
            "Lecture : ~{0}/s  |  Temps restant : ~{1}", "Estimation du temps de lecture", "Traitement des ressources",
            "Ressources prêtes");

        private static readonly ContentLoadingText German = new("Laden", "Dein Abenteuer geht gleich weiter",
            "Spielressourcen", "Musik und Sound", "{0}%   {1} / {2} MiB", "{0} / {1} Dateien bereit",
            "Leserate: ~{0}/s  |  Restzeit: ~{1}", "Lesezeit wird geschätzt", "Ressourcen werden verarbeitet",
            "Ressourcen bereit");

        private static readonly ContentLoadingText Italian = new("Caricamento",
            "L’avventura continuerà appena tutto sarà pronto",
            "Risorse di gioco", "Musica e suoni", "{0}%   {1} / {2} MiB", "{0} / {1} file pronti",
            "Lettura: ~{0}/s  |  Tempo restante: ~{1}", "Stima del tempo di lettura", "Elaborazione delle risorse",
            "Risorse pronte");

        private static readonly ContentLoadingText Japanese = new("読み込み中", "準備ができたら冒険を続けます",
            "ゲームのリソース", "音楽と効果音", "{0}%   {1} / {2} MiB", "準備完了 {0} / {1} ファイル",
            "読み込み：約{0}/s  |  残り時間：約{1}", "残り時間を確認中", "データを処理中", "準備完了");

        private static readonly ContentLoadingText Korean = new("불러오는 중", "준비가 끝나면 모험이 계속됩니다",
            "게임 리소스", "음악과 효과음", "{0}%   {1} / {2} MiB", "파일 {0} / {1}개 준비 완료",
            "읽기: 약 {0}/s  |  남은 시간: 약 {1}", "남은 시간 계산 중", "리소스 준비 중", "준비 완료");

        private static readonly ContentLoadingText Russian = new("Загрузка", "Приключение продолжится после загрузки",
            "Ресурсы игры", "Музыка и звуки", "{0}%   {1} / {2} MiB", "Готово файлов: {0} / {1}",
            "Чтение: ~{0}/s  |  Осталось: ~{1}", "Расчёт времени чтения", "Обработка ресурсов", "Ресурсы готовы");

        private static readonly ContentLoadingText Spanish = new("Cargando",
            "Tu aventura continuará cuando todo esté listo",
            "Recursos del juego", "Música y sonido", "{0}%   {1} / {2} MiB", "{0} / {1} archivos listos",
            "Lectura: ~{0}/s  |  Tiempo restante: ~{1}", "Estimando tiempo de lectura", "Procesando recursos",
            "Recursos listos");

        private static readonly ContentLoadingText Brazilian = new("Carregando",
            "Sua aventura continuará quando tudo estiver pronto",
            "Recursos do jogo", "Música e sons", "{0}%   {1} / {2} MiB", "{0} / {1} arquivos prontos",
            "Leitura: ~{0}/s  |  Tempo restante: ~{1}", "Estimando tempo de leitura", "Processando recursos",
            "Recursos prontos");

        public static ContentLoadingText ForLanguage(string id) => id switch
        {
            "schinese" => Chinese,
            "french" => French,
            "german" => German,
            "italian" => Italian,
            "japanese" => Japanese,
            "korean" => Korean,
            "russian" => Russian,
            "spanish" => Spanish,
            "brazilian" => Brazilian,
            _ => English
        };
    }
}
