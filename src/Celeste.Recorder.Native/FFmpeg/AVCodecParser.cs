namespace FFmpeg
{
    public struct AVCodecParser
    {
        public int7 codec_ids;

        public int priv_data_size;

        public AVCodecParser_parser_init_func parser_init;

        public AVCodecParser_parser_parse_func parser_parse;

        public AVCodecParser_parser_close_func parser_close;

        public AVCodecParser_split_func split;
    }
}
