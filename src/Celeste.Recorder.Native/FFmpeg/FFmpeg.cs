using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public static class FFmpeg
    {
        public static readonly int EAGAIN = (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? 35 : 11);

        public static readonly int ENOMEM = 12;

        public static readonly int EINVAL = 22;

        public static readonly int EPIPE = 32;

        public const int _WIN32_WINNT = 1538;

        public const int AV_BUFFER_FLAG_READONLY = 1;

        public const int AV_BUFFERSINK_FLAG_NO_REQUEST = 2;

        public const int AV_BUFFERSINK_FLAG_PEEK = 1;

        public static readonly ulong AV_CH_BACK_CENTER = 256uL;

        public static readonly ulong AV_CH_BACK_LEFT = 16uL;

        public static readonly ulong AV_CH_BACK_RIGHT = 32uL;

        public static readonly ulong AV_CH_BOTTOM_FRONT_CENTER = 274877906944uL;

        public static readonly ulong AV_CH_BOTTOM_FRONT_LEFT = 549755813888uL;

        public static readonly ulong AV_CH_BOTTOM_FRONT_RIGHT = 1099511627776uL;

        public static readonly ulong AV_CH_FRONT_CENTER = 4uL;

        public static readonly ulong AV_CH_FRONT_LEFT = 1uL;

        public static readonly ulong AV_CH_FRONT_LEFT_OF_CENTER = 64uL;

        public static readonly ulong AV_CH_FRONT_RIGHT = 2uL;

        public static readonly ulong AV_CH_FRONT_RIGHT_OF_CENTER = 128uL;

        public static readonly ulong AV_CH_LAYOUT_2_1 = AV_CH_LAYOUT_STEREO | AV_CH_BACK_CENTER;

        public static readonly ulong AV_CH_LAYOUT_2_2 = AV_CH_LAYOUT_STEREO | AV_CH_SIDE_LEFT | AV_CH_SIDE_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_22POINT2 = AV_CH_LAYOUT_5POINT1_BACK | AV_CH_FRONT_LEFT_OF_CENTER |
                                                             AV_CH_FRONT_RIGHT_OF_CENTER | AV_CH_BACK_CENTER |
                                                             AV_CH_LOW_FREQUENCY_2 | AV_CH_SIDE_LEFT |
                                                             AV_CH_SIDE_RIGHT |
                                                             AV_CH_TOP_FRONT_LEFT | AV_CH_TOP_FRONT_RIGHT |
                                                             AV_CH_TOP_FRONT_CENTER | AV_CH_TOP_CENTER |
                                                             AV_CH_TOP_BACK_LEFT | AV_CH_TOP_BACK_RIGHT |
                                                             AV_CH_TOP_SIDE_LEFT | AV_CH_TOP_SIDE_RIGHT |
                                                             AV_CH_TOP_BACK_CENTER | AV_CH_BOTTOM_FRONT_CENTER |
                                                             AV_CH_BOTTOM_FRONT_LEFT | AV_CH_BOTTOM_FRONT_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_2POINT1 = AV_CH_LAYOUT_STEREO | AV_CH_LOW_FREQUENCY;

        public static readonly ulong AV_CH_LAYOUT_3POINT1 = AV_CH_LAYOUT_SURROUND | AV_CH_LOW_FREQUENCY;

        public static readonly ulong AV_CH_LAYOUT_4POINT0 = AV_CH_LAYOUT_SURROUND | AV_CH_BACK_CENTER;

        public static readonly ulong AV_CH_LAYOUT_4POINT1 = AV_CH_LAYOUT_4POINT0 | AV_CH_LOW_FREQUENCY;

        public static readonly ulong AV_CH_LAYOUT_5POINT0 = AV_CH_LAYOUT_SURROUND | AV_CH_SIDE_LEFT | AV_CH_SIDE_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_5POINT0_BACK =
            AV_CH_LAYOUT_SURROUND | AV_CH_BACK_LEFT | AV_CH_BACK_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_5POINT1 = AV_CH_LAYOUT_5POINT0 | AV_CH_LOW_FREQUENCY;

        public static readonly ulong AV_CH_LAYOUT_5POINT1_BACK = AV_CH_LAYOUT_5POINT0_BACK | AV_CH_LOW_FREQUENCY;

        public static readonly ulong AV_CH_LAYOUT_6POINT0 = AV_CH_LAYOUT_5POINT0 | AV_CH_BACK_CENTER;

        public static readonly ulong AV_CH_LAYOUT_6POINT0_FRONT =
            AV_CH_LAYOUT_2_2 | AV_CH_FRONT_LEFT_OF_CENTER | AV_CH_FRONT_RIGHT_OF_CENTER;

        public static readonly ulong AV_CH_LAYOUT_6POINT1 = AV_CH_LAYOUT_5POINT1 | AV_CH_BACK_CENTER;

        public static readonly ulong AV_CH_LAYOUT_6POINT1_BACK = AV_CH_LAYOUT_5POINT1_BACK | AV_CH_BACK_CENTER;

        public static readonly ulong AV_CH_LAYOUT_6POINT1_FRONT = AV_CH_LAYOUT_6POINT0_FRONT | AV_CH_LOW_FREQUENCY;

        public static readonly ulong AV_CH_LAYOUT_7POINT0 = AV_CH_LAYOUT_5POINT0 | AV_CH_BACK_LEFT | AV_CH_BACK_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_7POINT0_FRONT =
            AV_CH_LAYOUT_5POINT0 | AV_CH_FRONT_LEFT_OF_CENTER | AV_CH_FRONT_RIGHT_OF_CENTER;

        public static readonly ulong AV_CH_LAYOUT_7POINT1 = AV_CH_LAYOUT_5POINT1 | AV_CH_BACK_LEFT | AV_CH_BACK_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_7POINT1_TOP_BACK =
            AV_CH_LAYOUT_5POINT1_BACK | AV_CH_TOP_FRONT_LEFT | AV_CH_TOP_FRONT_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_7POINT1_WIDE =
            AV_CH_LAYOUT_5POINT1 | AV_CH_FRONT_LEFT_OF_CENTER | AV_CH_FRONT_RIGHT_OF_CENTER;

        public static readonly ulong AV_CH_LAYOUT_7POINT1_WIDE_BACK =
            AV_CH_LAYOUT_5POINT1_BACK | AV_CH_FRONT_LEFT_OF_CENTER | AV_CH_FRONT_RIGHT_OF_CENTER;

        public static readonly ulong AV_CH_LAYOUT_CUBE =
            AV_CH_LAYOUT_QUAD | AV_CH_TOP_FRONT_LEFT | AV_CH_TOP_FRONT_RIGHT |
            AV_CH_TOP_BACK_LEFT | AV_CH_TOP_BACK_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_HEXADECAGONAL = AV_CH_LAYOUT_OCTAGONAL | AV_CH_WIDE_LEFT |
                                                                  AV_CH_WIDE_RIGHT | AV_CH_TOP_BACK_LEFT |
                                                                  AV_CH_TOP_BACK_RIGHT | AV_CH_TOP_BACK_CENTER |
                                                                  AV_CH_TOP_FRONT_CENTER | AV_CH_TOP_FRONT_LEFT |
                                                                  AV_CH_TOP_FRONT_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_HEXAGONAL = AV_CH_LAYOUT_5POINT0_BACK | AV_CH_BACK_CENTER;

        public static readonly ulong AV_CH_LAYOUT_MONO = AV_CH_FRONT_CENTER;

        public const ulong AV_CH_LAYOUT_NATIVE = 9223372036854775808uL;

        public static readonly ulong AV_CH_LAYOUT_OCTAGONAL =
            AV_CH_LAYOUT_5POINT0 | AV_CH_BACK_LEFT | AV_CH_BACK_CENTER | AV_CH_BACK_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_QUAD = AV_CH_LAYOUT_STEREO | AV_CH_BACK_LEFT | AV_CH_BACK_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_STEREO = AV_CH_FRONT_LEFT | AV_CH_FRONT_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_STEREO_DOWNMIX = AV_CH_STEREO_LEFT | AV_CH_STEREO_RIGHT;

        public static readonly ulong AV_CH_LAYOUT_SURROUND = AV_CH_LAYOUT_STEREO | AV_CH_FRONT_CENTER;

        public static readonly ulong AV_CH_LOW_FREQUENCY = 8uL;

        public static readonly ulong AV_CH_LOW_FREQUENCY_2 = 34359738368uL;

        public static readonly ulong AV_CH_SIDE_LEFT = 512uL;

        public static readonly ulong AV_CH_SIDE_RIGHT = 1024uL;

        public static readonly ulong AV_CH_STEREO_LEFT = 536870912uL;

        public static readonly ulong AV_CH_STEREO_RIGHT = 1073741824uL;

        public static readonly ulong AV_CH_SURROUND_DIRECT_LEFT = 8589934592uL;

        public static readonly ulong AV_CH_SURROUND_DIRECT_RIGHT = 17179869184uL;

        public static readonly ulong AV_CH_TOP_BACK_CENTER = 65536uL;

        public static readonly ulong AV_CH_TOP_BACK_LEFT = 32768uL;

        public static readonly ulong AV_CH_TOP_BACK_RIGHT = 131072uL;

        public static readonly ulong AV_CH_TOP_CENTER = 2048uL;

        public static readonly ulong AV_CH_TOP_FRONT_CENTER = 8192uL;

        public static readonly ulong AV_CH_TOP_FRONT_LEFT = 4096uL;

        public static readonly ulong AV_CH_TOP_FRONT_RIGHT = 16384uL;

        public static readonly ulong AV_CH_TOP_SIDE_LEFT = 68719476736uL;

        public static readonly ulong AV_CH_TOP_SIDE_RIGHT = 137438953472uL;

        public static readonly ulong AV_CH_WIDE_LEFT = 2147483648uL;

        public static readonly ulong AV_CH_WIDE_RIGHT = 4294967296uL;

        public static AVChannelLayout AV_CHANNEL_LAYOUT_2_1 = AV_CHANNEL_LAYOUT_MASK(3, AV_CH_LAYOUT_2_1);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_2_2 = AV_CHANNEL_LAYOUT_MASK(4, AV_CH_LAYOUT_2_2);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_22POINT2 = AV_CHANNEL_LAYOUT_MASK(24, AV_CH_LAYOUT_22POINT2);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_2POINT1 = AV_CHANNEL_LAYOUT_MASK(3, AV_CH_LAYOUT_2POINT1);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_3POINT1 = AV_CHANNEL_LAYOUT_MASK(4, AV_CH_LAYOUT_3POINT1);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_4POINT0 = AV_CHANNEL_LAYOUT_MASK(4, AV_CH_LAYOUT_4POINT0);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_4POINT1 = AV_CHANNEL_LAYOUT_MASK(5, AV_CH_LAYOUT_4POINT1);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT0 = AV_CHANNEL_LAYOUT_MASK(5, AV_CH_LAYOUT_5POINT0);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT0_BACK =
            AV_CHANNEL_LAYOUT_MASK(5, AV_CH_LAYOUT_5POINT0_BACK);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT1 = AV_CHANNEL_LAYOUT_MASK(6, AV_CH_LAYOUT_5POINT1);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_5POINT1_BACK =
            AV_CHANNEL_LAYOUT_MASK(6, AV_CH_LAYOUT_5POINT1_BACK);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT0 = AV_CHANNEL_LAYOUT_MASK(6, AV_CH_LAYOUT_6POINT0);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT0_FRONT =
            AV_CHANNEL_LAYOUT_MASK(6, AV_CH_LAYOUT_6POINT0_FRONT);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT1 = AV_CHANNEL_LAYOUT_MASK(7, AV_CH_LAYOUT_6POINT1);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT1_BACK =
            AV_CHANNEL_LAYOUT_MASK(7, AV_CH_LAYOUT_6POINT1_BACK);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_6POINT1_FRONT =
            AV_CHANNEL_LAYOUT_MASK(7, AV_CH_LAYOUT_6POINT1_FRONT);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT0 = AV_CHANNEL_LAYOUT_MASK(7, AV_CH_LAYOUT_7POINT0);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT0_FRONT =
            AV_CHANNEL_LAYOUT_MASK(7, AV_CH_LAYOUT_7POINT0_FRONT);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1 = AV_CHANNEL_LAYOUT_MASK(8, AV_CH_LAYOUT_7POINT1);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1_TOP_BACK =
            AV_CHANNEL_LAYOUT_MASK(8, AV_CH_LAYOUT_7POINT1_TOP_BACK);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1_WIDE =
            AV_CHANNEL_LAYOUT_MASK(8, AV_CH_LAYOUT_7POINT1_WIDE);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_7POINT1_WIDE_BACK =
            AV_CHANNEL_LAYOUT_MASK(8, AV_CH_LAYOUT_7POINT1_WIDE_BACK);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_AMBISONIC_FIRST_ORDER = new AVChannelLayout
        {
            order = AVChannelOrder.AV_CHANNEL_ORDER_AMBISONIC,
            nb_channels = 4,
            u = new AVChannelLayout_u
            {
                mask = 0uL
            }
        };

        public static AVChannelLayout AV_CHANNEL_LAYOUT_CUBE = AV_CHANNEL_LAYOUT_MASK(8, AV_CH_LAYOUT_CUBE);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_HEXADECAGONAL =
            AV_CHANNEL_LAYOUT_MASK(16, AV_CH_LAYOUT_HEXADECAGONAL);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_HEXAGONAL = AV_CHANNEL_LAYOUT_MASK(6, AV_CH_LAYOUT_HEXAGONAL);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_MONO = AV_CHANNEL_LAYOUT_MASK(1, AV_CH_LAYOUT_MONO);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_OCTAGONAL = AV_CHANNEL_LAYOUT_MASK(8, AV_CH_LAYOUT_OCTAGONAL);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_QUAD = AV_CHANNEL_LAYOUT_MASK(4, AV_CH_LAYOUT_QUAD);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_STEREO = AV_CHANNEL_LAYOUT_MASK(2, AV_CH_LAYOUT_STEREO);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_STEREO_DOWNMIX =
            AV_CHANNEL_LAYOUT_MASK(2, AV_CH_LAYOUT_STEREO_DOWNMIX);

        public static AVChannelLayout AV_CHANNEL_LAYOUT_SURROUND = AV_CHANNEL_LAYOUT_MASK(3, AV_CH_LAYOUT_SURROUND);

        public const int AV_CODEC_CAP_AVOID_PROBING = 131072;

        public const int AV_CODEC_CAP_CHANNEL_CONF = 1024;

        public const int AV_CODEC_CAP_DELAY = 32;

        public const int AV_CODEC_CAP_DR1 = 2;

        public const int AV_CODEC_CAP_DRAW_HORIZ_BAND = 1;

        public const int AV_CODEC_CAP_ENCODER_FLUSH = 2097152;

        public const int AV_CODEC_CAP_ENCODER_RECON_FRAME = 4194304;

        public const int AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE = 1048576;

        public const int AV_CODEC_CAP_EXPERIMENTAL = 512;

        public const int AV_CODEC_CAP_FRAME_THREADS = 4096;

        public const int AV_CODEC_CAP_HARDWARE = 262144;

        public const int AV_CODEC_CAP_HYBRID = 524288;

        public const int AV_CODEC_CAP_OTHER_THREADS = 32768;

        public const int AV_CODEC_CAP_PARAM_CHANGE = 16384;

        public const int AV_CODEC_CAP_SLICE_THREADS = 8192;

        public const int AV_CODEC_CAP_SMALL_LAST_FRAME = 64;

        public const int AV_CODEC_CAP_SUBFRAMES = 256;

        public const int AV_CODEC_CAP_VARIABLE_FRAME_SIZE = 65536;

        public const int AV_CODEC_EXPORT_DATA_FILM_GRAIN = 8;

        public const int AV_CODEC_EXPORT_DATA_MVS = 1;

        public const int AV_CODEC_EXPORT_DATA_PRFT = 2;

        public const int AV_CODEC_EXPORT_DATA_VIDEO_ENC_PARAMS = 4;

        public const int AV_CODEC_FLAG_4MV = 4;

        public const int AV_CODEC_FLAG_AC_PRED = 16777216;

        public const int AV_CODEC_FLAG_BITEXACT = 8388608;

        public const uint AV_CODEC_FLAG_CLOSED_GOP = 2147483648u;

        public const int AV_CODEC_FLAG_COPY_OPAQUE = 128;

        public const int AV_CODEC_FLAG_DROPCHANGED = 32;

        public const int AV_CODEC_FLAG_FRAME_DURATION = 256;

        public const int AV_CODEC_FLAG_GLOBAL_HEADER = 4194304;

        public const int AV_CODEC_FLAG_GRAY = 8192;

        public const int AV_CODEC_FLAG_INTERLACED_DCT = 262144;

        public const int AV_CODEC_FLAG_INTERLACED_ME = 536870912;

        public const int AV_CODEC_FLAG_LOOP_FILTER = 2048;

        public const int AV_CODEC_FLAG_LOW_DELAY = 524288;

        public const int AV_CODEC_FLAG_OUTPUT_CORRUPT = 8;

        public const int AV_CODEC_FLAG_PASS1 = 512;

        public const int AV_CODEC_FLAG_PASS2 = 1024;

        public const int AV_CODEC_FLAG_PSNR = 32768;

        public const int AV_CODEC_FLAG_QPEL = 16;

        public const int AV_CODEC_FLAG_QSCALE = 2;

        public const int AV_CODEC_FLAG_RECON_FRAME = 64;

        public const int AV_CODEC_FLAG_UNALIGNED = 1;

        public const int AV_CODEC_FLAG2_CHUNKS = 32768;

        public const int AV_CODEC_FLAG2_EXPORT_MVS = 268435456;

        public const int AV_CODEC_FLAG2_FAST = 1;

        public const uint AV_CODEC_FLAG2_ICC_PROFILES = 2147483648u;

        public const int AV_CODEC_FLAG2_IGNORE_CROP = 65536;

        public const int AV_CODEC_FLAG2_LOCAL_HEADER = 8;

        public const int AV_CODEC_FLAG2_NO_OUTPUT = 4;

        public const int AV_CODEC_FLAG2_RO_FLUSH_NOOP = 1073741824;

        public const int AV_CODEC_FLAG2_SHOW_ALL = 4194304;

        public const int AV_CODEC_FLAG2_SKIP_MANUAL = 536870912;

        public static readonly int AV_CODEC_ID_H265 = 173;

        public static readonly int AV_CODEC_ID_H266 = 196;

        public static readonly int AV_CODEC_ID_IFF_BYTERUN1 = 136;

        public const int AV_CODEC_PROP_BITMAP_SUB = 65536;

        public const int AV_CODEC_PROP_INTRA_ONLY = 1;

        public const int AV_CODEC_PROP_LOSSLESS = 4;

        public const int AV_CODEC_PROP_LOSSY = 2;

        public const int AV_CODEC_PROP_REORDER = 8;

        public const int AV_CODEC_PROP_TEXT_SUB = 131072;

        public const int AV_CPU_FLAG_3DNOW = 4;

        public const int AV_CPU_FLAG_3DNOWEXT = 32;

        public const int AV_CPU_FLAG_AESNI = 524288;

        public const int AV_CPU_FLAG_ALTIVEC = 1;

        public const int AV_CPU_FLAG_ARMV5TE = 1;

        public const int AV_CPU_FLAG_ARMV6 = 2;

        public const int AV_CPU_FLAG_ARMV6T2 = 4;

        public const int AV_CPU_FLAG_ARMV8 = 64;

        public const int AV_CPU_FLAG_ATOM = 268435456;

        public const int AV_CPU_FLAG_AVX = 16384;

        public const int AV_CPU_FLAG_AVX2 = 32768;

        public const int AV_CPU_FLAG_AVX512 = 1048576;

        public const int AV_CPU_FLAG_AVX512ICL = 2097152;

        public const int AV_CPU_FLAG_AVXSLOW = 134217728;

        public const int AV_CPU_FLAG_BMI1 = 131072;

        public const int AV_CPU_FLAG_BMI2 = 262144;

        public const int AV_CPU_FLAG_CMOV = 4096;

        public const int AV_CPU_FLAG_FMA3 = 65536;

        public const int AV_CPU_FLAG_FMA4 = 2048;

        public const uint AV_CPU_FLAG_FORCE = 2147483648u;

        public const int AV_CPU_FLAG_LASX = 2;

        public const int AV_CPU_FLAG_LSX = 1;

        public const int AV_CPU_FLAG_MMI = 1;

        public const int AV_CPU_FLAG_MMX = 1;

        public const int AV_CPU_FLAG_MMX2 = 2;

        public const int AV_CPU_FLAG_MMXEXT = 2;

        public const int AV_CPU_FLAG_MSA = 2;

        public const int AV_CPU_FLAG_NEON = 32;

        public const int AV_CPU_FLAG_POWER8 = 4;

        public const int AV_CPU_FLAG_RVB_BASIC = 128;

        public const int AV_CPU_FLAG_RVD = 4;

        public const int AV_CPU_FLAG_RVF = 2;

        public const int AV_CPU_FLAG_RVI = 1;

        public const int AV_CPU_FLAG_RVV_F32 = 16;

        public const int AV_CPU_FLAG_RVV_F64 = 64;

        public const int AV_CPU_FLAG_RVV_I32 = 8;

        public const int AV_CPU_FLAG_RVV_I64 = 32;

        public const int AV_CPU_FLAG_SETEND = 65536;

        public const int AV_CPU_FLAG_SLOW_GATHER = 33554432;

        public const int AV_CPU_FLAG_SSE = 8;

        public const int AV_CPU_FLAG_SSE2 = 16;

        public const int AV_CPU_FLAG_SSE2SLOW = 1073741824;

        public const int AV_CPU_FLAG_SSE3 = 64;

        public const int AV_CPU_FLAG_SSE3SLOW = 536870912;

        public const int AV_CPU_FLAG_SSE4 = 256;

        public const int AV_CPU_FLAG_SSE42 = 512;

        public const int AV_CPU_FLAG_SSSE3 = 128;

        public const int AV_CPU_FLAG_SSSE3SLOW = 67108864;

        public const int AV_CPU_FLAG_VFP = 8;

        public const int AV_CPU_FLAG_VFP_VM = 128;

        public const int AV_CPU_FLAG_VFPV3 = 16;

        public const int AV_CPU_FLAG_VSX = 2;

        public const int AV_CPU_FLAG_XOP = 1024;

        public const int AV_DICT_APPEND = 32;

        public const int AV_DICT_DONT_OVERWRITE = 16;

        public const int AV_DICT_DONT_STRDUP_KEY = 4;

        public const int AV_DICT_DONT_STRDUP_VAL = 8;

        public const int AV_DICT_IGNORE_SUFFIX = 2;

        public const int AV_DICT_MATCH_CASE = 1;

        public const int AV_DICT_MULTIKEY = 64;

        public const int AV_DISPOSITION_ATTACHED_PIC = 1024;

        public const int AV_DISPOSITION_CAPTIONS = 65536;

        public const int AV_DISPOSITION_CLEAN_EFFECTS = 512;

        public const int AV_DISPOSITION_COMMENT = 8;

        public const int AV_DISPOSITION_DEFAULT = 1;

        public const int AV_DISPOSITION_DEPENDENT = 524288;

        public const int AV_DISPOSITION_DESCRIPTIONS = 131072;

        public const int AV_DISPOSITION_DUB = 2;

        public const int AV_DISPOSITION_FORCED = 64;

        public const int AV_DISPOSITION_HEARING_IMPAIRED = 128;

        public const int AV_DISPOSITION_KARAOKE = 32;

        public const int AV_DISPOSITION_LYRICS = 16;

        public const int AV_DISPOSITION_METADATA = 262144;

        public const int AV_DISPOSITION_NON_DIEGETIC = 4096;

        public const int AV_DISPOSITION_ORIGINAL = 4;

        public const int AV_DISPOSITION_STILL_IMAGE = 1048576;

        public const int AV_DISPOSITION_TIMED_THUMBNAILS = 2048;

        public const int AV_DISPOSITION_VISUAL_IMPAIRED = 256;

        public const int AV_EF_AGGRESSIVE = 262144;

        public const int AV_EF_BITSTREAM = 2;

        public const int AV_EF_BUFFER = 4;

        public const int AV_EF_CAREFUL = 65536;

        public const int AV_EF_COMPLIANT = 131072;

        public const int AV_EF_CRCCHECK = 1;

        public const int AV_EF_EXPLODE = 8;

        public const int AV_EF_IGNORE_ERR = 32768;

        public const int AV_ERROR_MAX_STRING_SIZE = 64;

        public const int AV_FOURCC_MAX_STRING_SIZE = 32;

        public const int AV_FRAME_FILENAME_FLAGS_MULTIPLE = 1;

        public const int AV_FRAME_FLAG_CORRUPT = 1;

        public const int AV_FRAME_FLAG_DISCARD = 4;

        public const int AV_GET_BUFFER_FLAG_REF = 1;

        public const int AV_GET_ENCODE_BUFFER_FLAG_REF = 1;

        public const int AV_HAVE_BIGENDIAN = 0;

        public const int AV_HAVE_FAST_UNALIGNED = 1;

        public const int AV_HWACCEL_CODEC_CAP_EXPERIMENTAL = 512;

        public const int AV_HWACCEL_FLAG_ALLOW_HIGH_DEPTH = 2;

        public const int AV_HWACCEL_FLAG_ALLOW_PROFILE_MISMATCH = 4;

        public const int AV_HWACCEL_FLAG_IGNORE_LEVEL = 1;

        public const int AV_HWACCEL_FLAG_UNSAFE_OUTPUT = 8;

        public const int AV_INPUT_BUFFER_MIN_SIZE = 16384;

        public const int AV_INPUT_BUFFER_PADDING_SIZE = 64;

        public const int AV_LOG_DEBUG = 48;

        public const int AV_LOG_ERROR = 16;

        public const int AV_LOG_FATAL = 8;

        public const int AV_LOG_INFO = 32;

        public const int AV_LOG_MAX_OFFSET = 64;

        public const int AV_LOG_PANIC = 0;

        public const int AV_LOG_PRINT_LEVEL = 2;

        public const int AV_LOG_QUIET = -8;

        public const int AV_LOG_SKIP_REPEATED = 1;

        public const int AV_LOG_TRACE = 56;

        public const int AV_LOG_VERBOSE = 40;

        public const int AV_LOG_WARNING = 24;

        public static readonly long AV_NOPTS_VALUE = (long)UINT64_C(9223372036854775808uL);

        public const int AV_NUM_DATA_POINTERS = 8;

        public const int AV_OPT_ALLOW_NULL = 4;

        public const int AV_OPT_FLAG_AUDIO_PARAM = 8;

        public const int AV_OPT_FLAG_BSF_PARAM = 256;

        public const int AV_OPT_FLAG_CHILD_CONSTS = 262144;

        public const int AV_OPT_FLAG_DECODING_PARAM = 2;

        public const int AV_OPT_FLAG_DEPRECATED = 131072;

        public const int AV_OPT_FLAG_ENCODING_PARAM = 1;

        public const int AV_OPT_FLAG_EXPORT = 64;

        public const int AV_OPT_FLAG_FILTERING_PARAM = 65536;

        public const int AV_OPT_FLAG_READONLY = 128;

        public const int AV_OPT_FLAG_RUNTIME_PARAM = 32768;

        public const int AV_OPT_FLAG_SUBTITLE_PARAM = 32;

        public const int AV_OPT_FLAG_VIDEO_PARAM = 16;

        public const int AV_OPT_MULTI_COMPONENT_RANGE = 4096;

        public const int AV_OPT_SEARCH_CHILDREN = 1;

        public const int AV_OPT_SEARCH_FAKE_OBJ = 2;

        public const int AV_OPT_SERIALIZE_OPT_FLAGS_EXACT = 2;

        public const int AV_OPT_SERIALIZE_SKIP_DEFAULTS = 1;

        public const int AV_PARSER_PTS_NB = 4;

        public const int AV_PIX_FMT_FLAG_ALPHA = 128;

        public const int AV_PIX_FMT_FLAG_BAYER = 256;

        public const int AV_PIX_FMT_FLAG_BE = 1;

        public const int AV_PIX_FMT_FLAG_BITSTREAM = 4;

        public const int AV_PIX_FMT_FLAG_FLOAT = 512;

        public const int AV_PIX_FMT_FLAG_HWACCEL = 8;

        public const int AV_PIX_FMT_FLAG_PAL = 2;

        public const int AV_PIX_FMT_FLAG_PLANAR = 16;

        public const int AV_PIX_FMT_FLAG_RGB = 32;

        public static readonly int AV_PKT_DATA_QUALITY_FACTOR = 8;

        public const int AV_PKT_FLAG_CORRUPT = 2;

        public const int AV_PKT_FLAG_DISCARD = 4;

        public const int AV_PKT_FLAG_DISPOSABLE = 16;

        public const int AV_PKT_FLAG_KEY = 1;

        public const int AV_PKT_FLAG_TRUSTED = 8;

        public const int AV_PROGRAM_RUNNING = 1;

        public const int AV_PTS_WRAP_ADD_OFFSET = 1;

        public const int AV_PTS_WRAP_IGNORE = 0;

        public const int AV_PTS_WRAP_SUB_OFFSET = -1;

        public const int AV_SUBTITLE_FLAG_FORCED = 1;

        public const int AV_TIME_BASE = 1000000;

        public const int AV_TIMECODE_STR_SIZE = 23;

        public static readonly int AVERROR_BSF_NOT_FOUND = FFERRTAG(248, 'B', 'S', 'F');

        public static readonly int AVERROR_BUFFER_TOO_SMALL = FFERRTAG('B', 'U', 'F', 'S');

        public static readonly int AVERROR_BUG = FFERRTAG('B', 'U', 'G', '!');

        public static readonly int AVERROR_BUG2 = FFERRTAG('B', 'U', 'G', ' ');

        public static readonly int AVERROR_DECODER_NOT_FOUND = FFERRTAG(248, 'D', 'E', 'C');

        public static readonly int AVERROR_DEMUXER_NOT_FOUND = FFERRTAG(248, 'D', 'E', 'M');

        public static readonly int AVERROR_ENCODER_NOT_FOUND = FFERRTAG(248, 'E', 'N', 'C');

        public static readonly int AVERROR_EOF = FFERRTAG('E', 'O', 'F', ' ');

        public static readonly int AVERROR_EXIT = FFERRTAG('E', 'X', 'I', 'T');

        public const int AVERROR_EXPERIMENTAL = -733130664;

        public static readonly int AVERROR_EXTERNAL = FFERRTAG('E', 'X', 'T', ' ');

        public static readonly int AVERROR_FILTER_NOT_FOUND = FFERRTAG(248, 'F', 'I', 'L');

        public static readonly int AVERROR_HTTP_BAD_REQUEST = FFERRTAG(248, '4', '0', '0');

        public static readonly int AVERROR_HTTP_FORBIDDEN = FFERRTAG(248, '4', '0', '3');

        public static readonly int AVERROR_HTTP_NOT_FOUND = FFERRTAG(248, '4', '0', '4');

        public static readonly int AVERROR_HTTP_OTHER_4XX = FFERRTAG(248, '4', 'X', 'X');

        public static readonly int AVERROR_HTTP_SERVER_ERROR = FFERRTAG(248, '5', 'X', 'X');

        public static readonly int AVERROR_HTTP_UNAUTHORIZED = FFERRTAG(248, '4', '0', '1');

        public const int AVERROR_INPUT_CHANGED = -1668179713;

        public static readonly int AVERROR_INVALIDDATA = FFERRTAG('I', 'N', 'D', 'A');

        public static readonly int AVERROR_MUXER_NOT_FOUND = FFERRTAG(248, 'M', 'U', 'X');

        public static readonly int AVERROR_OPTION_NOT_FOUND = FFERRTAG(248, 'O', 'P', 'T');

        public const int AVERROR_OUTPUT_CHANGED = -1668179714;

        public static readonly int AVERROR_PATCHWELCOME = FFERRTAG('P', 'A', 'W', 'E');

        public static readonly int AVERROR_PROTOCOL_NOT_FOUND = FFERRTAG(248, 'P', 'R', 'O');

        public static readonly int AVERROR_STREAM_NOT_FOUND = FFERRTAG(248, 'S', 'T', 'R');

        public static readonly int AVERROR_UNKNOWN = FFERRTAG('U', 'N', 'K', 'N');

        public const int AVFILTER_CMD_FLAG_FAST = 2;

        public const int AVFILTER_CMD_FLAG_ONE = 1;

        public const int AVFILTER_FLAG_DYNAMIC_INPUTS = 1;

        public const int AVFILTER_FLAG_DYNAMIC_OUTPUTS = 2;

        public const int AVFILTER_FLAG_METADATA_ONLY = 8;

        public const int AVFILTER_FLAG_SLICE_THREADS = 4;

        public const int AVFILTER_FLAG_SUPPORT_TIMELINE = 196608;

        public const int AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC = 65536;

        public const int AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL = 131072;

        public const int AVFILTER_THREAD_SLICE = 1;

        public const int AVFMT_ALLOW_FLUSH = 65536;

        public const int AVFMT_AVOID_NEG_TS_AUTO = -1;

        public const int AVFMT_AVOID_NEG_TS_DISABLED = 0;

        public const int AVFMT_AVOID_NEG_TS_MAKE_NON_NEGATIVE = 1;

        public const int AVFMT_AVOID_NEG_TS_MAKE_ZERO = 2;

        public const int AVFMT_EVENT_FLAG_METADATA_UPDATED = 1;

        public const int AVFMT_EXPERIMENTAL = 4;

        public const int AVFMT_FLAG_AUTO_BSF = 2097152;

        public const int AVFMT_FLAG_BITEXACT = 1024;

        public const int AVFMT_FLAG_CUSTOM_IO = 128;

        public const int AVFMT_FLAG_DISCARD_CORRUPT = 256;

        public const int AVFMT_FLAG_FAST_SEEK = 524288;

        public const int AVFMT_FLAG_FLUSH_PACKETS = 512;

        public const int AVFMT_FLAG_GENPTS = 1;

        public const int AVFMT_FLAG_IGNDTS = 8;

        public const int AVFMT_FLAG_IGNIDX = 2;

        public const int AVFMT_FLAG_NOBUFFER = 64;

        public const int AVFMT_FLAG_NOFILLIN = 16;

        public const int AVFMT_FLAG_NONBLOCK = 4;

        public const int AVFMT_FLAG_NOPARSE = 32;

        public const int AVFMT_FLAG_SHORTEST = 1048576;

        public const int AVFMT_FLAG_SORT_DTS = 65536;

        public const int AVFMT_GENERIC_INDEX = 256;

        public const int AVFMT_GLOBALHEADER = 64;

        public const int AVFMT_NEEDNUMBER = 2;

        public const int AVFMT_NO_BYTE_SEEK = 32768;

        public const int AVFMT_NOBINSEARCH = 8192;

        public const int AVFMT_NODIMENSIONS = 2048;

        public const int AVFMT_NOFILE = 1;

        public const int AVFMT_NOGENSEARCH = 16384;

        public const int AVFMT_NOSTREAMS = 4096;

        public const int AVFMT_NOTIMESTAMPS = 128;

        public const int AVFMT_SEEK_TO_PTS = 67108864;

        public const int AVFMT_SHOW_IDS = 8;

        public const int AVFMT_TS_DISCONT = 512;

        public const int AVFMT_TS_NEGATIVE = 262144;

        public const int AVFMT_TS_NONSTRICT = 131072;

        public const int AVFMT_VARIABLE_FPS = 1024;

        public const int AVFMTCTX_NOHEADER = 1;

        public const int AVFMTCTX_UNSEEKABLE = 2;

        public const int AVINDEX_DISCARD_FRAME = 2;

        public const int AVINDEX_KEYFRAME = 1;

        public const int AVIO_FLAG_DIRECT = 32768;

        public const int AVIO_FLAG_NONBLOCK = 8;

        public const int AVIO_FLAG_READ = 1;

        public const int AVIO_FLAG_READ_WRITE = 3;

        public const int AVIO_FLAG_WRITE = 2;

        public const int AVIO_SEEKABLE_NORMAL = 1;

        public const int AVIO_SEEKABLE_TIME = 2;

        public const int AVPALETTE_COUNT = 256;

        public const int AVPALETTE_SIZE = 1024;

        public const int AVPROBE_PADDING_SIZE = 32;

        public const int AVPROBE_SCORE_EXTENSION = 50;

        public const int AVPROBE_SCORE_MAX = 100;

        public const int AVPROBE_SCORE_MIME = 75;

        public const int AVPROBE_SCORE_RETRY = 25;

        public const int AVPROBE_SCORE_STREAM_RETRY = 24;

        public const int AVSEEK_FLAG_ANY = 4;

        public const int AVSEEK_FLAG_BACKWARD = 1;

        public const int AVSEEK_FLAG_BYTE = 2;

        public const int AVSEEK_FLAG_FRAME = 8;

        public const int AVSEEK_FORCE = 131072;

        public const int AVSEEK_SIZE = 65536;

        public const int AVSTREAM_EVENT_FLAG_METADATA_UPDATED = 1;

        public const int AVSTREAM_EVENT_FLAG_NEW_PACKETS = 2;

        public const int AVSTREAM_INIT_IN_INIT_OUTPUT = 1;

        public const int AVSTREAM_INIT_IN_WRITE_HEADER = 0;

        public const bool FF_API_AV_FOPEN_UTF8 = true;

        public const bool FF_API_AVCODEC_CHROMA_POS = true;

        public const bool FF_API_AVCTX_FRAME_NUMBER = true;

        public const bool FF_API_AVFORMAT_IO_CLOSE = true;

        public const bool FF_API_AVIODIRCONTEXT = true;

        public const bool FF_API_AYUV_CODECID = true;

        public const bool FF_API_COMPUTE_PKT_FIELDS2 = true;

        public const bool FF_API_FIFO_OLD_API = true;

        public const bool FF_API_FIFO_PEEK2 = true;

        public const bool FF_API_FRAME_PICTURE_NUMBER = true;

        public const bool FF_API_GET_END_PTS = true;

        public const bool FF_API_IDCT_NONE = true;

        public const bool FF_API_INIT_PACKET = true;

        public const bool FF_API_OLD_CHANNEL_LAYOUT = true;

        public const bool FF_API_PKT_DURATION = true;

        public const int FF_API_R_FRAME_RATE = 1;

        public const bool FF_API_REORDERED_OPAQUE = true;

        public const bool FF_API_SVTAV1_OPTS = true;

        public const bool FF_API_VT_HWACCEL_CONTEXT = true;

        public const bool FF_API_VT_OUTPUT_CALLBACK = true;

        public const bool FF_API_XVMC = true;

        public const int FF_BUG_AMV = 32;

        public const int FF_BUG_AUTODETECT = 1;

        public const int FF_BUG_DC_CLIP = 4096;

        public const int FF_BUG_DIRECT_BLOCKSIZE = 512;

        public const int FF_BUG_EDGE = 1024;

        public const int FF_BUG_HPEL_CHROMA = 2048;

        public const int FF_BUG_IEDGE = 32768;

        public const int FF_BUG_MS = 8192;

        public const int FF_BUG_NO_PADDING = 16;

        public const int FF_BUG_QPEL_CHROMA = 64;

        public const int FF_BUG_QPEL_CHROMA2 = 256;

        public const int FF_BUG_STD_QPEL = 128;

        public const int FF_BUG_TRUNCATED = 16384;

        public const int FF_BUG_UMP4 = 8;

        public const int FF_BUG_XVID_ILACE = 4;

        public const int FF_CMP_BIT = 5;

        public const int FF_CMP_CHROMA = 256;

        public const int FF_CMP_DCT = 3;

        public const int FF_CMP_DCT264 = 14;

        public const int FF_CMP_DCTMAX = 13;

        public const int FF_CMP_MEDIAN_SAD = 15;

        public const int FF_CMP_NSSE = 10;

        public const int FF_CMP_PSNR = 4;

        public const int FF_CMP_RD = 6;

        public const int FF_CMP_SAD = 0;

        public const int FF_CMP_SATD = 2;

        public const int FF_CMP_SSE = 1;

        public const int FF_CMP_VSAD = 8;

        public const int FF_CMP_VSSE = 9;

        public const int FF_CMP_W53 = 11;

        public const int FF_CMP_W97 = 12;

        public const int FF_CMP_ZERO = 7;

        public const bool FF_CODEC_CRYSTAL_HD = true;

        public const int FF_CODEC_PROPERTY_CLOSED_CAPTIONS = 2;

        public const int FF_CODEC_PROPERTY_FILM_GRAIN = 4;

        public const int FF_CODEC_PROPERTY_LOSSLESS = 1;

        public const int FF_COMPLIANCE_EXPERIMENTAL = -2;

        public const int FF_COMPLIANCE_NORMAL = 0;

        public const int FF_COMPLIANCE_STRICT = 1;

        public const int FF_COMPLIANCE_UNOFFICIAL = -1;

        public const int FF_COMPLIANCE_VERY_STRICT = 2;

        public const int FF_COMPRESSION_DEFAULT = -1;

        public const int FF_DCT_ALTIVEC = 5;

        public const int FF_DCT_AUTO = 0;

        public const int FF_DCT_FAAN = 6;

        public const int FF_DCT_FASTINT = 1;

        public const int FF_DCT_INT = 2;

        public const int FF_DCT_MMX = 3;

        public const int FF_DEBUG_BITSTREAM = 4;

        public const int FF_DEBUG_BUFFERS = 32768;

        public const int FF_DEBUG_BUGS = 4096;

        public const int FF_DEBUG_DCT_COEFF = 64;

        public const int FF_DEBUG_ER = 1024;

        public const int FF_DEBUG_GREEN_MD = 8388608;

        public const int FF_DEBUG_MB_TYPE = 8;

        public const int FF_DEBUG_MMCO = 2048;

        public const int FF_DEBUG_NOMC = 16777216;

        public const int FF_DEBUG_PICT_INFO = 1;

        public const int FF_DEBUG_QP = 16;

        public const int FF_DEBUG_RC = 2;

        public const int FF_DEBUG_SKIP = 128;

        public const int FF_DEBUG_STARTCODE = 256;

        public const int FF_DEBUG_THREADS = 65536;

        public const int FF_DECODE_ERROR_CONCEALMENT_ACTIVE = 4;

        public const int FF_DECODE_ERROR_DECODE_SLICES = 8;

        public const int FF_DECODE_ERROR_INVALID_BITSTREAM = 1;

        public const int FF_DECODE_ERROR_MISSING_REFERENCE = 2;

        public const int FF_DXVA2_WORKAROUND_INTEL_CLEARVIDEO = 2;

        public const int FF_DXVA2_WORKAROUND_SCALING_LIST_ZIGZAG = 1;

        public const int FF_EC_DEBLOCK = 2;

        public const int FF_EC_FAVOR_INTER = 256;

        public const int FF_EC_GUESS_MVS = 1;

        public const int FF_FDEBUG_TS = 1;

        public const int FF_IDCT_ALTIVEC = 8;

        public const int FF_IDCT_ARM = 7;

        public const int FF_IDCT_AUTO = 0;

        public const int FF_IDCT_FAAN = 20;

        public const int FF_IDCT_INT = 1;

        public const int FF_IDCT_NONE = 24;

        public const int FF_IDCT_SIMPLE = 2;

        public const int FF_IDCT_SIMPLEARM = 10;

        public const int FF_IDCT_SIMPLEARMV5TE = 16;

        public const int FF_IDCT_SIMPLEARMV6 = 17;

        public const int FF_IDCT_SIMPLEAUTO = 128;

        public const int FF_IDCT_SIMPLEMMX = 3;

        public const int FF_IDCT_SIMPLENEON = 22;

        public const int FF_IDCT_XVID = 14;

        public const int FF_LAMBDA_MAX = 32767;

        public const int FF_LAMBDA_SCALE = 128;

        public const int FF_LAMBDA_SHIFT = 7;

        public const int FF_LEVEL_UNKNOWN = -99;

        public const int FF_LOSS_ALPHA = 8;

        public const int FF_LOSS_CHROMA = 32;

        public const int FF_LOSS_COLORQUANT = 16;

        public const int FF_LOSS_COLORSPACE = 4;

        public const int FF_LOSS_DEPTH = 2;

        public const int FF_LOSS_EXCESS_DEPTH = 128;

        public const int FF_LOSS_EXCESS_RESOLUTION = 64;

        public const int FF_LOSS_RESOLUTION = 1;

        public const int FF_MB_DECISION_BITS = 1;

        public const int FF_MB_DECISION_RD = 2;

        public const int FF_MB_DECISION_SIMPLE = 0;

        public const int FF_PROFILE_AAC_ELD = 38;

        public const int FF_PROFILE_AAC_HE = 4;

        public const int FF_PROFILE_AAC_HE_V2 = 28;

        public const int FF_PROFILE_AAC_LD = 22;

        public const int FF_PROFILE_AAC_LOW = 1;

        public const int FF_PROFILE_AAC_LTP = 3;

        public const int FF_PROFILE_AAC_MAIN = 0;

        public const int FF_PROFILE_AAC_SSR = 2;

        public const int FF_PROFILE_ARIB_PROFILE_A = 0;

        public const int FF_PROFILE_ARIB_PROFILE_C = 1;

        public const int FF_PROFILE_AV1_HIGH = 1;

        public const int FF_PROFILE_AV1_MAIN = 0;

        public const int FF_PROFILE_AV1_PROFESSIONAL = 2;

        public const int FF_PROFILE_DNXHD = 0;

        public const int FF_PROFILE_DNXHR_444 = 5;

        public const int FF_PROFILE_DNXHR_HQ = 3;

        public const int FF_PROFILE_DNXHR_HQX = 4;

        public const int FF_PROFILE_DNXHR_LB = 1;

        public const int FF_PROFILE_DNXHR_SQ = 2;

        public const int FF_PROFILE_DTS = 20;

        public const int FF_PROFILE_DTS_96_24 = 40;

        public const int FF_PROFILE_DTS_ES = 30;

        public const int FF_PROFILE_DTS_EXPRESS = 70;

        public const int FF_PROFILE_DTS_HD_HRA = 50;

        public const int FF_PROFILE_DTS_HD_MA = 60;

        public const int FF_PROFILE_H264_BASELINE = 66;

        public const int FF_PROFILE_H264_CAVLC_444 = 44;

        public const int FF_PROFILE_H264_CONSTRAINED = 512;

        public const int FF_PROFILE_H264_CONSTRAINED_BASELINE = 578;

        public const int FF_PROFILE_H264_EXTENDED = 88;

        public const int FF_PROFILE_H264_HIGH = 100;

        public const int FF_PROFILE_H264_HIGH_10 = 110;

        public const int FF_PROFILE_H264_HIGH_10_INTRA = 2158;

        public const int FF_PROFILE_H264_HIGH_422 = 122;

        public const int FF_PROFILE_H264_HIGH_422_INTRA = 2170;

        public const int FF_PROFILE_H264_HIGH_444 = 144;

        public const int FF_PROFILE_H264_HIGH_444_INTRA = 2292;

        public const int FF_PROFILE_H264_HIGH_444_PREDICTIVE = 244;

        public const int FF_PROFILE_H264_INTRA = 2048;

        public const int FF_PROFILE_H264_MAIN = 77;

        public const int FF_PROFILE_H264_MULTIVIEW_HIGH = 118;

        public const int FF_PROFILE_H264_STEREO_HIGH = 128;

        public const int FF_PROFILE_HEVC_MAIN = 1;

        public const int FF_PROFILE_HEVC_MAIN_10 = 2;

        public const int FF_PROFILE_HEVC_MAIN_STILL_PICTURE = 3;

        public const int FF_PROFILE_HEVC_REXT = 4;

        public const int FF_PROFILE_JPEG2000_CSTREAM_NO_RESTRICTION = 32768;

        public const int FF_PROFILE_JPEG2000_CSTREAM_RESTRICTION_0 = 1;

        public const int FF_PROFILE_JPEG2000_CSTREAM_RESTRICTION_1 = 2;

        public const int FF_PROFILE_JPEG2000_DCINEMA_2K = 3;

        public const int FF_PROFILE_JPEG2000_DCINEMA_4K = 4;

        public const int FF_PROFILE_KLVA_ASYNC = 1;

        public const int FF_PROFILE_KLVA_SYNC = 0;

        public const int FF_PROFILE_MJPEG_HUFFMAN_BASELINE_DCT = 192;

        public const int FF_PROFILE_MJPEG_HUFFMAN_EXTENDED_SEQUENTIAL_DCT = 193;

        public const int FF_PROFILE_MJPEG_HUFFMAN_LOSSLESS = 195;

        public const int FF_PROFILE_MJPEG_HUFFMAN_PROGRESSIVE_DCT = 194;

        public const int FF_PROFILE_MJPEG_JPEG_LS = 247;

        public const int FF_PROFILE_MPEG2_422 = 0;

        public const int FF_PROFILE_MPEG2_AAC_HE = 131;

        public const int FF_PROFILE_MPEG2_AAC_LOW = 128;

        public const int FF_PROFILE_MPEG2_HIGH = 1;

        public const int FF_PROFILE_MPEG2_MAIN = 4;

        public const int FF_PROFILE_MPEG2_SIMPLE = 5;

        public const int FF_PROFILE_MPEG2_SNR_SCALABLE = 3;

        public const int FF_PROFILE_MPEG2_SS = 2;

        public const int FF_PROFILE_MPEG4_ADVANCED_CODING = 11;

        public const int FF_PROFILE_MPEG4_ADVANCED_CORE = 12;

        public const int FF_PROFILE_MPEG4_ADVANCED_REAL_TIME = 9;

        public const int FF_PROFILE_MPEG4_ADVANCED_SCALABLE_TEXTURE = 13;

        public const int FF_PROFILE_MPEG4_ADVANCED_SIMPLE = 15;

        public const int FF_PROFILE_MPEG4_BASIC_ANIMATED_TEXTURE = 7;

        public const int FF_PROFILE_MPEG4_CORE = 2;

        public const int FF_PROFILE_MPEG4_CORE_SCALABLE = 10;

        public const int FF_PROFILE_MPEG4_HYBRID = 8;

        public const int FF_PROFILE_MPEG4_MAIN = 3;

        public const int FF_PROFILE_MPEG4_N_BIT = 4;

        public const int FF_PROFILE_MPEG4_SCALABLE_TEXTURE = 5;

        public const int FF_PROFILE_MPEG4_SIMPLE = 0;

        public const int FF_PROFILE_MPEG4_SIMPLE_FACE_ANIMATION = 6;

        public const int FF_PROFILE_MPEG4_SIMPLE_SCALABLE = 1;

        public const int FF_PROFILE_MPEG4_SIMPLE_STUDIO = 14;

        public const int FF_PROFILE_PRORES_4444 = 4;

        public const int FF_PROFILE_PRORES_HQ = 3;

        public const int FF_PROFILE_PRORES_LT = 1;

        public const int FF_PROFILE_PRORES_PROXY = 0;

        public const int FF_PROFILE_PRORES_STANDARD = 2;

        public const int FF_PROFILE_PRORES_XQ = 5;

        public const int FF_PROFILE_RESERVED = -100;

        public const int FF_PROFILE_SBC_MSBC = 1;

        public const int FF_PROFILE_UNKNOWN = -99;

        public const int FF_PROFILE_VC1_ADVANCED = 3;

        public const int FF_PROFILE_VC1_COMPLEX = 2;

        public const int FF_PROFILE_VC1_MAIN = 1;

        public const int FF_PROFILE_VC1_SIMPLE = 0;

        public const int FF_PROFILE_VP9_0 = 0;

        public const int FF_PROFILE_VP9_1 = 1;

        public const int FF_PROFILE_VP9_2 = 2;

        public const int FF_PROFILE_VP9_3 = 3;

        public const int FF_PROFILE_VVC_MAIN_10 = 1;

        public const int FF_PROFILE_VVC_MAIN_10_444 = 33;

        public const int FF_QP2LAMBDA = 118;

        public const int FF_QUALITY_SCALE = 128;

        public const int FF_SUB_CHARENC_MODE_AUTOMATIC = 0;

        public const int FF_SUB_CHARENC_MODE_DO_NOTHING = -1;

        public const int FF_SUB_CHARENC_MODE_IGNORE = 2;

        public const int FF_SUB_CHARENC_MODE_PRE_DECODER = 1;

        public const int FF_THREAD_FRAME = 1;

        public const int FF_THREAD_SLICE = 2;

        public static readonly int LIBAVCODEC_BUILD = LIBAVCODEC_VERSION_INT;

        public const string LIBAVCODEC_IDENT = "Lavc";

        public static readonly string LIBAVCODEC_VERSION = AV_VERSION(60, 3, 100);

        public static readonly int LIBAVCODEC_VERSION_INT = AV_VERSION_INT(60, 3, 100);

        public const int LIBAVCODEC_VERSION_MAJOR = 60;

        public const int LIBAVCODEC_VERSION_MICRO = 100;

        public const int LIBAVCODEC_VERSION_MINOR = 3;

        public static readonly int LIBAVDEVICE_BUILD = LIBAVDEVICE_VERSION_INT;

        public const string LIBAVDEVICE_IDENT = "Lavd";

        public static readonly string LIBAVDEVICE_VERSION = AV_VERSION(60, 1, 100);

        public static readonly int LIBAVDEVICE_VERSION_INT = AV_VERSION_INT(60, 1, 100);

        public const int LIBAVDEVICE_VERSION_MAJOR = 60;

        public const int LIBAVDEVICE_VERSION_MICRO = 100;

        public const int LIBAVDEVICE_VERSION_MINOR = 1;

        public static readonly int LIBAVFILTER_BUILD = LIBAVFILTER_VERSION_INT;

        public const string LIBAVFILTER_IDENT = "Lavfi";

        public static readonly string LIBAVFILTER_VERSION = AV_VERSION(9, 3, 100);

        public static readonly int LIBAVFILTER_VERSION_INT = AV_VERSION_INT(9, 3, 100);

        public const int LIBAVFILTER_VERSION_MAJOR = 9;

        public const int LIBAVFILTER_VERSION_MICRO = 100;

        public const int LIBAVFILTER_VERSION_MINOR = 3;

        public static readonly int LIBAVFORMAT_BUILD = LIBAVFORMAT_VERSION_INT;

        public const string LIBAVFORMAT_IDENT = "Lavf";

        public static readonly string LIBAVFORMAT_VERSION = AV_VERSION(60, 3, 100);

        public static readonly int LIBAVFORMAT_VERSION_INT = AV_VERSION_INT(60, 3, 100);

        public const int LIBAVFORMAT_VERSION_MAJOR = 60;

        public const int LIBAVFORMAT_VERSION_MICRO = 100;

        public const int LIBAVFORMAT_VERSION_MINOR = 3;

        public static readonly int LIBAVUTIL_BUILD = LIBAVUTIL_VERSION_INT;

        public const string LIBAVUTIL_IDENT = "Lavu";

        public static readonly string LIBAVUTIL_VERSION = AV_VERSION(58, 2, 100);

        public static readonly int LIBAVUTIL_VERSION_INT = AV_VERSION_INT(58, 2, 100);

        public const int LIBAVUTIL_VERSION_MAJOR = 58;

        public const int LIBAVUTIL_VERSION_MICRO = 100;

        public const int LIBAVUTIL_VERSION_MINOR = 2;

        public static readonly int LIBPOSTPROC_BUILD = LIBPOSTPROC_VERSION_INT;

        public const string LIBPOSTPROC_IDENT = "postproc";

        public static readonly string LIBPOSTPROC_VERSION = AV_VERSION(57, 1, 100);

        public static readonly int LIBPOSTPROC_VERSION_INT = AV_VERSION_INT(57, 1, 100);

        public const int LIBPOSTPROC_VERSION_MAJOR = 57;

        public const int LIBPOSTPROC_VERSION_MICRO = 100;

        public const int LIBPOSTPROC_VERSION_MINOR = 1;

        public static readonly int LIBSWRESAMPLE_BUILD = LIBSWRESAMPLE_VERSION_INT;

        public const string LIBSWRESAMPLE_IDENT = "SwR";

        public static readonly string LIBSWRESAMPLE_VERSION = AV_VERSION(4, 10, 100);

        public static readonly int LIBSWRESAMPLE_VERSION_INT = AV_VERSION_INT(4, 10, 100);

        public const int LIBSWRESAMPLE_VERSION_MAJOR = 4;

        public const int LIBSWRESAMPLE_VERSION_MICRO = 100;

        public const int LIBSWRESAMPLE_VERSION_MINOR = 10;

        public static readonly int LIBSWSCALE_BUILD = LIBSWSCALE_VERSION_INT;

        public const string LIBSWSCALE_IDENT = "SwS";

        public static readonly string LIBSWSCALE_VERSION = AV_VERSION(7, 1, 100);

        public static readonly int LIBSWSCALE_VERSION_INT = AV_VERSION_INT(7, 1, 100);

        public const int LIBSWSCALE_VERSION_MAJOR = 7;

        public const int LIBSWSCALE_VERSION_MICRO = 100;

        public const int LIBSWSCALE_VERSION_MINOR = 1;

        public const double M_E = Math.E;

        public const double M_LN10 = 2.302585092994046;

        public const double M_LN2 = 0.6931471805599453;

        public const double M_LOG2_10 = 3.321928094887362;

        public const double M_PHI = 1.618033988749895;

        public const double M_PI = Math.PI;

        public const double M_PI_2 = Math.PI / 2.0;

        public const double M_SQRT1_2 = 0.7071067811865476;

        public const double M_SQRT2 = 1.4142135623730951;

        public const int PARSER_FLAG_COMPLETE_FRAMES = 1;

        public const int PARSER_FLAG_FETCHED_OFFSET = 4;

        public const int PARSER_FLAG_ONCE = 2;

        public const int PARSER_FLAG_USE_CODEC_TS = 4096;

        public const int PP_CPU_CAPS_3DNOW = 1073741824;

        public const int PP_CPU_CAPS_ALTIVEC = 268435456;

        public const int PP_CPU_CAPS_AUTO = 524288;

        public const uint PP_CPU_CAPS_MMX = 2147483648u;

        public const int PP_CPU_CAPS_MMX2 = 536870912;

        public const int PP_FORMAT = 8;

        public const int PP_FORMAT_411 = 10;

        public const int PP_FORMAT_420 = 25;

        public const int PP_FORMAT_422 = 9;

        public const int PP_FORMAT_440 = 24;

        public const int PP_FORMAT_444 = 8;

        public const int PP_PICT_TYPE_QP2 = 16;

        public const int PP_QUALITY_MAX = 6;

        public const int SLICE_FLAG_ALLOW_FIELD = 2;

        public const int SLICE_FLAG_ALLOW_PLANE = 4;

        public const int SLICE_FLAG_CODED_ORDER = 1;

        public const int SWR_FLAG_RESAMPLE = 1;

        public const int SWS_ACCURATE_RND = 262144;

        public const int SWS_AREA = 32;

        public const int SWS_BICUBIC = 4;

        public const int SWS_BICUBLIN = 64;

        public const int SWS_BILINEAR = 2;

        public const int SWS_BITEXACT = 524288;

        public const int SWS_CS_BT2020 = 9;

        public const int SWS_CS_DEFAULT = 5;

        public const int SWS_CS_FCC = 4;

        public const int SWS_CS_ITU601 = 5;

        public const int SWS_CS_ITU624 = 5;

        public const int SWS_CS_ITU709 = 1;

        public const int SWS_CS_SMPTE170M = 5;

        public const int SWS_CS_SMPTE240M = 7;

        public const int SWS_DIRECT_BGR = 32768;

        public const int SWS_ERROR_DIFFUSION = 8388608;

        public const int SWS_FAST_BILINEAR = 1;

        public const int SWS_FULL_CHR_H_INP = 16384;

        public const int SWS_FULL_CHR_H_INT = 8192;

        public const int SWS_GAUSS = 128;

        public const int SWS_LANCZOS = 512;

        public const double SWS_MAX_REDUCE_CUTOFF = 0.002;

        public const int SWS_PARAM_DEFAULT = 123456;

        public const int SWS_POINT = 16;

        public const int SWS_PRINT_INFO = 4096;

        public const int SWS_SINC = 256;

        public const int SWS_SPLINE = 1024;

        public const int SWS_SRC_V_CHR_DROP_MASK = 196608;

        public const int SWS_SRC_V_CHR_DROP_SHIFT = 16;

        public const int SWS_X = 8;


        [DllImport("avcodec", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete(
            "This function is deprecated. Once it's removed, sizeof(AVPacket) will not be a part of the ABI anymore.")]
        public unsafe static extern void av_init_packet(AVPacket* pkt);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate AVPacket* D_av_packet_alloc();

        private static D_av_packet_alloc d_av_packet_alloc;

        public unsafe static AVPacket* av_packet_alloc() => (d_av_packet_alloc ??
                                                             (d_av_packet_alloc =
                                                                 NativeBindings.Get<D_av_packet_alloc>("avcodec",
                                                                     "av_packet_alloc")))();


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void D_av_packet_free(AVPacket** pkt);

        private static D_av_packet_free d_av_packet_free;

        public unsafe static void av_packet_free(AVPacket** pkt) => (d_av_packet_free ??
                                                                     (d_av_packet_free =
                                                                         NativeBindings.Get<D_av_packet_free>("avcodec",
                                                                             "av_packet_free")))(pkt);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void D_av_packet_rescale_ts(AVPacket* pkt, AVRational tb_src, AVRational tb_dst);

        private static D_av_packet_rescale_ts d_av_packet_rescale_ts;

        public unsafe static void av_packet_rescale_ts(AVPacket* pkt, AVRational tb_src, AVRational tb_dst) =>
            (d_av_packet_rescale_ts ?? (d_av_packet_rescale_ts =
                NativeBindings.Get<D_av_packet_rescale_ts>("avcodec", "av_packet_rescale_ts")))(pkt, tb_src, tb_dst);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate AVCodecContext* D_avcodec_alloc_context3(AVCodec* codec);

        private static D_avcodec_alloc_context3 d_avcodec_alloc_context3;

        public unsafe static AVCodecContext* avcodec_alloc_context3(AVCodec* codec) => (d_avcodec_alloc_context3 ??
            (d_avcodec_alloc_context3 =
                NativeBindings.Get<D_avcodec_alloc_context3>("avcodec", "avcodec_alloc_context3")))(codec);

        [DllImport("avcodec", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("Use av_chroma_location_pos_to_enum() instead.")]
        public static extern AVChromaLocation avcodec_chroma_pos_to_enum(int xpos, int ypos);


        [DllImport("avcodec", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("Use av_chroma_location_enum_to_pos() instead.")]
        public unsafe static extern int avcodec_enum_to_chroma_pos(int* xpos, int* ypos, AVChromaLocation pos);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate AVCodec* D_avcodec_find_encoder(AVCodecID id);

        private static D_avcodec_find_encoder d_avcodec_find_encoder;

        public unsafe static AVCodec* avcodec_find_encoder(AVCodecID id) => (d_avcodec_find_encoder ??
                                                                             (d_avcodec_find_encoder =
                                                                                 NativeBindings
                                                                                     .Get<D_avcodec_find_encoder>(
                                                                                         "avcodec",
                                                                                         "avcodec_find_encoder")))(
            id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate AVCodec* D_avcodec_find_encoder_by_name(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name);

        private static D_avcodec_find_encoder_by_name d_avcodec_find_encoder_by_name;

        public unsafe static AVCodec* avcodec_find_encoder_by_name(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name) =>
            (d_avcodec_find_encoder_by_name ?? (d_avcodec_find_encoder_by_name =
                NativeBindings.Get<D_avcodec_find_encoder_by_name>("avcodec", "avcodec_find_encoder_by_name")))(name);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void D_avcodec_free_context(AVCodecContext** avctx);

        private static D_avcodec_free_context d_avcodec_free_context;

        public unsafe static void avcodec_free_context(AVCodecContext** avctx) => (d_avcodec_free_context ??
            (d_avcodec_free_context =
                NativeBindings
                    .Get<D_avcodec_free_context>(
                        "avcodec",
                        "avcodec_free_context")))(
            avctx);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.ConstCharPtrMarshaler")]
        private delegate string D_avcodec_get_name(AVCodecID id);

        private static D_avcodec_get_name d_avcodec_get_name;

        public static string avcodec_get_name(AVCodecID id) => (d_avcodec_get_name ??
                                                                (d_avcodec_get_name =
                                                                    NativeBindings.Get<D_avcodec_get_name>("avcodec",
                                                                        "avcodec_get_name")))(id);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avcodec_open2(AVCodecContext* avctx, AVCodec* codec, AVDictionary** options);

        private static D_avcodec_open2 d_avcodec_open2;

        public unsafe static int avcodec_open2(AVCodecContext* avctx, AVCodec* codec, AVDictionary** options) =>
            (d_avcodec_open2 ?? (d_avcodec_open2 = NativeBindings.Get<D_avcodec_open2>("avcodec", "avcodec_open2")))(
                avctx,
                codec, options);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avcodec_parameters_from_context(AVCodecParameters* par, AVCodecContext* codec);

        private static D_avcodec_parameters_from_context d_avcodec_parameters_from_context;

        public unsafe static int avcodec_parameters_from_context(AVCodecParameters* par, AVCodecContext* codec) =>
            (d_avcodec_parameters_from_context ?? (d_avcodec_parameters_from_context =
                NativeBindings.Get<D_avcodec_parameters_from_context>("avcodec", "avcodec_parameters_from_context")))(
                par,
                codec);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avcodec_receive_packet(AVCodecContext* avctx, AVPacket* avpkt);

        private static D_avcodec_receive_packet d_avcodec_receive_packet;

        public unsafe static int avcodec_receive_packet(AVCodecContext* avctx, AVPacket* avpkt) =>
            (d_avcodec_receive_packet ?? (d_avcodec_receive_packet =
                NativeBindings.Get<D_avcodec_receive_packet>("avcodec", "avcodec_receive_packet")))(avctx, avpkt);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avcodec_send_frame(AVCodecContext* avctx, AVFrame* frame);

        private static D_avcodec_send_frame d_avcodec_send_frame;

        public unsafe static int avcodec_send_frame(AVCodecContext* avctx, AVFrame* frame) => (d_avcodec_send_frame ??
            (d_avcodec_send_frame = NativeBindings.Get<D_avcodec_send_frame>("avcodec", "avcodec_send_frame")))(avctx,
            frame);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint D_avcodec_version();

        private static D_avcodec_version d_avcodec_version;

        public static uint avcodec_version() => (d_avcodec_version ??
                                                 (d_avcodec_version =
                                                     NativeBindings.Get<D_avcodec_version>("avcodec",
                                                         "avcodec_version")))();


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_interleaved_write_frame(AVFormatContext* s, AVPacket* pkt);

        private static D_av_interleaved_write_frame d_av_interleaved_write_frame;

        public unsafe static int av_interleaved_write_frame(AVFormatContext* s, AVPacket* pkt) =>
            (d_av_interleaved_write_frame ?? (d_av_interleaved_write_frame =
                NativeBindings.Get<D_av_interleaved_write_frame>("avformat", "av_interleaved_write_frame")))(s, pkt);


        [DllImport("avformat", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete(" ")]
        public unsafe static extern long av_stream_get_end_pts(AVStream* st);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_write_trailer(AVFormatContext* s);

        private static D_av_write_trailer d_av_write_trailer;

        public unsafe static int av_write_trailer(AVFormatContext* s) => (d_av_write_trailer ??
                                                                          (d_av_write_trailer =
                                                                              NativeBindings.Get<D_av_write_trailer>(
                                                                                  "avformat", "av_write_trailer")))(s);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avformat_alloc_output_context2(AVFormatContext** ctx, AVOutputFormat* oformat,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string format_name,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string filename);

        private static D_avformat_alloc_output_context2 d_avformat_alloc_output_context2;

        public unsafe static int avformat_alloc_output_context2(AVFormatContext** ctx, AVOutputFormat* oformat,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string format_name,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string filename) =>
            (d_avformat_alloc_output_context2 ?? (d_avformat_alloc_output_context2 =
                NativeBindings.Get<D_avformat_alloc_output_context2>("avformat", "avformat_alloc_output_context2")))(
                ctx,
                oformat, format_name, filename);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void D_avformat_free_context(AVFormatContext* s);

        private static D_avformat_free_context d_avformat_free_context;

        public unsafe static void avformat_free_context(AVFormatContext* s) => (d_avformat_free_context ??
            (d_avformat_free_context =
                NativeBindings
                    .Get<D_avformat_free_context>(
                        "avformat",
                        "avformat_free_context")))(s);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate AVStream* D_avformat_new_stream(AVFormatContext* s, AVCodec* c);

        private static D_avformat_new_stream d_avformat_new_stream;

        public unsafe static AVStream* avformat_new_stream(AVFormatContext* s, AVCodec* c) => (d_avformat_new_stream ??
            (d_avformat_new_stream = NativeBindings.Get<D_avformat_new_stream>("avformat", "avformat_new_stream")))(s,
            c);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint D_avformat_version();

        private static D_avformat_version d_avformat_version;

        public static uint avformat_version() => (d_avformat_version ??
                                                  (d_avformat_version =
                                                      NativeBindings.Get<D_avformat_version>("avformat",
                                                          "avformat_version")))();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avformat_write_header(AVFormatContext* s, AVDictionary** options);

        private static D_avformat_write_header d_avformat_write_header;

        public unsafe static int avformat_write_header(AVFormatContext* s, AVDictionary** options) =>
            (d_avformat_write_header ?? (d_avformat_write_header =
                NativeBindings.Get<D_avformat_write_header>("avformat", "avformat_write_header")))(s, options);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avio_closep(AVIOContext** s);

        private static D_avio_closep d_avio_closep;

        public unsafe static int avio_closep(AVIOContext** s) =>
            (d_avio_closep ?? (d_avio_closep = NativeBindings.Get<D_avio_closep>("avformat", "avio_closep")))(s);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_avio_open(AVIOContext** s,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string url, int flags);

        private static D_avio_open d_avio_open;

        public unsafe static int avio_open(AVIOContext** s,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string url, int flags) =>
            (d_avio_open ?? (d_avio_open = NativeBindings.Get<D_avio_open>("avformat", "avio_open")))(s, url, flags);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate long D_avio_seek(AVIOContext* s, long offset, int whence);

        private static D_avio_seek d_avio_seek;

        public unsafe static long avio_seek(AVIOContext* s, long offset, int whence) =>
            (d_avio_seek ??
             (d_avio_seek = NativeBindings.Get<D_avio_seek>("avformat", "avio_seek")))(s, offset, whence);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_describe()")]
        public unsafe static extern void av_bprint_channel_layout(AVBPrint* bp, int nb_channels, ulong channel_layout);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_channel_layout_copy(AVChannelLayout* dst, AVChannelLayout* src);

        private static D_av_channel_layout_copy d_av_channel_layout_copy;

        public unsafe static int av_channel_layout_copy(AVChannelLayout* dst, AVChannelLayout* src) =>
            (d_av_channel_layout_copy ?? (d_av_channel_layout_copy =
                NativeBindings.Get<D_av_channel_layout_copy>("avutil", "av_channel_layout_copy")))(dst, src);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_channel_from_index()")]
        public static extern ulong av_channel_layout_extract_channel(ulong channel_layout, int index);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_dict_set(AVDictionary** pm,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string key,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string value, int flags);

        private static D_av_dict_set d_av_dict_set;

        public unsafe static int av_dict_set(AVDictionary** pm,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string key,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string value,
            int flags) =>
            (d_av_dict_set ?? (d_av_dict_set = NativeBindings.Get<D_av_dict_set>("avutil", "av_dict_set")))(pm, key,
                value,
                flags);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete(
            "Avoid using it, as on Windows, the FILE* allocated by this function may be allocated with a different CRT than the caller who uses the FILE*. No replacement provided in public API.")]
        public unsafe static extern _iobuf* av_fopen_utf8(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string path,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string mode);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate AVFrame* D_av_frame_alloc();

        private static D_av_frame_alloc d_av_frame_alloc;

        public unsafe static AVFrame* av_frame_alloc() => (d_av_frame_alloc ??
                                                           (d_av_frame_alloc =
                                                               NativeBindings.Get<D_av_frame_alloc>("avutil",
                                                                   "av_frame_alloc")))();


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void D_av_frame_free(AVFrame** frame);

        private static D_av_frame_free d_av_frame_free;

        public unsafe static void av_frame_free(AVFrame** frame) => (d_av_frame_free ??
                                                                     (d_av_frame_free =
                                                                         NativeBindings.Get<D_av_frame_free>("avutil",
                                                                             "av_frame_free")))(frame);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_frame_get_buffer(AVFrame* frame, int align);

        private static D_av_frame_get_buffer d_av_frame_get_buffer;

        public unsafe static int av_frame_get_buffer(AVFrame* frame, int align) => (d_av_frame_get_buffer ??
            (d_av_frame_get_buffer = NativeBindings.Get<D_av_frame_get_buffer>("avutil", "av_frame_get_buffer")))(frame,
            align);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_frame_make_writable(AVFrame* frame);

        private static D_av_frame_make_writable d_av_frame_make_writable;

        public unsafe static int av_frame_make_writable(AVFrame* frame) => (d_av_frame_make_writable ??
                                                                            (d_av_frame_make_writable =
                                                                                NativeBindings
                                                                                    .Get<D_av_frame_make_writable>(
                                                                                        "avutil",
                                                                                        "av_frame_make_writable")))(
            frame);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_description()")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.ConstCharPtrMarshaler")]
        public static extern string av_get_channel_description(ulong channel);

        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_from_string()")]
        public static extern ulong av_get_channel_layout(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name);

        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_index_from_channel()")]
        public static extern int av_get_channel_layout_channel_index(ulong channel_layout, ulong channel);

        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use AVChannelLayout.nb_channels")]
        public static extern int av_get_channel_layout_nb_channels(ulong channel_layout);

        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_describe()")]
        public unsafe static extern void av_get_channel_layout_string(byte* buf, int buf_size, int nb_channels,
            ulong channel_layout);

        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_name()")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.ConstCharPtrMarshaler")]
        public static extern string av_get_channel_name(ulong channel);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_default()")]
        public static extern long av_get_default_channel_layout(int nb_channels);

        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_from_string()")]
        public unsafe static extern int av_get_extended_channel_layout(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name,
            ulong* channel_layout, int* nb_channels);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use av_channel_layout_standard()")]
        public unsafe static extern int av_get_standard_channel_layout(uint index, ulong* layout, byte** name);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int D_av_log2(uint v);

        private static D_av_log2 d_av_log2;

        public static int av_log2(uint v) =>
            (d_av_log2 ?? (d_av_log2 = NativeBindings.Get<D_av_log2>("avutil", "av_log2")))(v);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete]
        public unsafe static extern int av_opt_get_channel_layout(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name,
            int search_flags, long* ch_layout);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete]
        public unsafe static extern int av_opt_set_channel_layout(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name,
            long ch_layout, int search_flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_opt_set_chlayout(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name,
            AVChannelLayout* layout, int search_flags);

        private static D_av_opt_set_chlayout d_av_opt_set_chlayout;

        public unsafe static int av_opt_set_chlayout(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name,
            AVChannelLayout* layout, int search_flags) =>
            (d_av_opt_set_chlayout ?? (d_av_opt_set_chlayout =
                NativeBindings.Get<D_av_opt_set_chlayout>("avutil", "av_opt_set_chlayout")))(obj, name, layout,
                search_flags);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_opt_set_int(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name, long val,
            int search_flags);

        private static D_av_opt_set_int d_av_opt_set_int;

        public unsafe static int av_opt_set_int(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name, long val,
            int search_flags) =>
            (d_av_opt_set_int ?? (d_av_opt_set_int = NativeBindings.Get<D_av_opt_set_int>("avutil", "av_opt_set_int")))(
                obj,
                name, val, search_flags);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_opt_set_sample_fmt(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name,
            AVSampleFormat fmt, int search_flags);

        private static D_av_opt_set_sample_fmt d_av_opt_set_sample_fmt;

        public unsafe static int av_opt_set_sample_fmt(void* obj,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string name,
            AVSampleFormat fmt, int search_flags) =>
            (d_av_opt_set_sample_fmt ?? (d_av_opt_set_sample_fmt =
                NativeBindings.Get<D_av_opt_set_sample_fmt>("avutil", "av_opt_set_sample_fmt")))(obj, name, fmt,
                search_flags);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate long D_av_rescale_q(long a, AVRational bq, AVRational cq);

        private static D_av_rescale_q d_av_rescale_q;

        public static long av_rescale_q(long a, AVRational bq, AVRational cq) => (d_av_rescale_q ??
            (d_av_rescale_q =
                NativeBindings.Get<D_av_rescale_q>(
                    "avutil", "av_rescale_q")))(a, bq,
            cq);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate long D_av_rescale_rnd(long a, long b, long c, AVRounding rnd);

        private static D_av_rescale_rnd d_av_rescale_rnd;

        public static long av_rescale_rnd(long a, long b, long c, AVRounding rnd) => (d_av_rescale_rnd ??
            (d_av_rescale_rnd = NativeBindings.Get<D_av_rescale_rnd>("avutil", "av_rescale_rnd")))(a, b, c, rnd);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_av_strerror(int errnum, byte* errbuf, ulong errbuf_size);

        private static D_av_strerror d_av_strerror;

        public unsafe static int av_strerror(int errnum, byte* errbuf, ulong errbuf_size) =>
            (d_av_strerror ?? (d_av_strerror = NativeBindings.Get<D_av_strerror>("avutil", "av_strerror")))(errnum,
                errbuf,
                errbuf_size);


        [DllImport("avutil", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("as fd numbers cannot be passed saftely between libs on some platforms")]
        public unsafe static extern int av_tempfile(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
            string prefix,
            byte** filename, int log_offset, void* log_ctx);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint D_avutil_version();

        private static D_avutil_version d_avutil_version;

        public static uint avutil_version() => (d_avutil_version ??
                                                (d_avutil_version =
                                                    NativeBindings.Get<D_avutil_version>("avutil",
                                                        "avutil_version")))();

        public static ulong UINT64_C<T>(T a)
        {
            return Convert.ToUInt64(a);
        }

        public static int AVERROR<T1>(T1 a)
        {
            return -Convert.ToInt32(a);
        }

        public static int MKTAG<T1, T2, T3, T4>(T1 a, T2 b, T3 c, T4 d)
        {
            return (int)(Convert.ToUInt32(a) | (Convert.ToUInt32(b) << 8) | (Convert.ToUInt32(c) << 16) |
                         (Convert.ToUInt32(d) << 24));
        }

        public static int FFERRTAG<T1, T2, T3, T4>(T1 a, T2 b, T3 c, T4 d)
        {
            return -MKTAG(a, b, c, d);
        }

        public static int AV_VERSION_INT<T1, T2, T3>(T1 a, T2 b, T3 c)
        {
            return (Convert.ToInt32(a) << 16) | (Convert.ToInt32(b) << 8) | Convert.ToInt32(c);
        }

        public static string AV_VERSION_DOT<T1, T2, T3>(T1 a, T2 b, T3 c)
        {
            return $"{a}.{b}.{c}";
        }

        public static string AV_VERSION<T1, T2, T3>(T1 a, T2 b, T3 c)
        {
            return AV_VERSION_DOT(a, b, c);
        }

        public static uint AV_VERSION_MAJOR(uint a)
        {
            return a >> 16;
        }

        public static uint AV_VERSION_MINOR(uint a)
        {
            return (a & 0xFF00) >> 8;
        }

        public static uint AV_VERSION_MICRO(uint a)
        {
            return a & 0xFF;
        }

        public static int av_ceil_log2_c(int x)
        {
            return av_log2((uint)((int)((long)x - 1L) << 1));
        }

        public static int av_clip_c(int a, int amin, int amax)
        {
            if (a < amin)
            {
                return amin;
            }

            if (a > amax)
            {
                return amax;
            }

            return a;
        }

        public static short av_clip_int16_c(int a)
        {
            if ((((long)a + 32768L) & -65536) != 0L)
            {
                return (short)((a >> 31) ^ 0x7FFF);
            }

            return (short)a;
        }

        public static sbyte av_clip_int8_c(int a)
        {
            if ((((long)a + 128L) & -256) != 0L)
            {
                return (sbyte)((a >> 31) ^ 0x7F);
            }

            return (sbyte)a;
        }

        public static int av_clip_intp2_c(int a, int p)
        {
            if ((((uint)a + (1 << p)) & ~((2 << p) - 1)) != 0L)
            {
                return (a >> 31) ^ ((1 << p) - 1);
            }

            return a;
        }

        public static ushort av_clip_uint16_c(int a)
        {
            if ((a & -65536) != 0)
            {
                return (ushort)(~a >> 31);
            }

            return (ushort)a;
        }

        public static byte av_clip_uint8_c(int a)
        {
            if ((a & -256) != 0)
            {
                return (byte)(~a >> 31);
            }

            return (byte)a;
        }

        public static uint av_clip_uintp2_c(int a, int p)
        {
            if ((a & ~((1 << p) - 1)) != 0)
            {
                return (uint)((~a >> 31) & ((1 << p) - 1));
            }

            return (uint)a;
        }

        public static long av_clip64_c(long a, long amin, long amax)
        {
            if (a < amin)
            {
                return amin;
            }

            if (a > amax)
            {
                return amax;
            }

            return a;
        }

        public static double av_clipd_c(double a, double amin, double amax)
        {
            if (!(((a > amin) ? a : amin) > amax))
            {
                if (!(a > amin))
                {
                    return amin;
                }

                return a;
            }

            return amax;
        }

        public static float av_clipf_c(float a, float amin, float amax)
        {
            if (!(((a > amin) ? a : amin) > amax))
            {
                if (!(a > amin))
                {
                    return amin;
                }

                return a;
            }

            return amax;
        }

        public static int av_clipl_int32_c(long a)
        {
            if (((a + 2147483648u) & -4294967296L) != 0L)
            {
                return (int)((a >> 63) ^ 0x7FFFFFFF);
            }

            return (int)a;
        }

        public static int av_cmp_q(AVRational a, AVRational b)
        {
            long num = (long)a.num * (long)b.den - (long)b.num * (long)a.den;
            if (num != 0L)
            {
                return (int)((num ^ a.den ^ b.den) >> 63) | 1;
            }

            if (b.den != 0 && a.den != 0)
            {
                return 0;
            }

            if (a.num != 0 && b.num != 0)
            {
                return (a.num >> 31) - (b.num >> 31);
            }

            return int.MinValue;
        }

        public static ulong av_double2int(double f)
        {
            return (ulong)f;
        }

        public static uint av_float2int(float f)
        {
            return (uint)f;
        }

        public static double av_int2double(ulong i)
        {
            return i;
        }

        public static float av_int2float(uint i)
        {
            return i;
        }

        public static AVRational av_inv_q(AVRational q)
        {
            return new AVRational
            {
                num = q.den,
                den = q.num
            };
        }

        public unsafe static byte* av_make_error_string(byte* errbuf, ulong errbuf_size, int errnum)
        {
            av_strerror(errnum, errbuf, errbuf_size);
            return errbuf;
        }

        public static AVRational av_make_q(int num, int den)
        {
            return new AVRational
            {
                num = num,
                den = den
            };
        }

        public static uint av_mod_uintp2_c(uint a, uint p)
        {
            return a & (uint)((1 << (int)p) - 1);
        }

        public static int av_parity_c(uint v)
        {
            return av_popcount_c(v) & 1;
        }

        public static int av_popcount_c(uint x)
        {
            x -= (x >> 1) & 0x55555555;
            x = (x & 0x33333333) + ((x >> 2) & 0x33333333);
            x = (x + (x >> 4)) & 0xF0F0F0F;
            x += x >> 8;
            return (int)((x + (x >> 16)) & 0x3F);
        }

        public static int av_popcount64_c(ulong x)
        {
            return av_popcount_c((uint)x) + av_popcount_c((uint)(x >> 32));
        }

        public static double av_q2d(AVRational a)
        {
            return (double)a.num / (double)a.den;
        }

        public static int av_sat_add32_c(int a, int b)
        {
            return av_clipl_int32_c((long)a + (long)b);
        }

        public static long av_sat_add64_c(long a, long b)
        {
            try
            {
                return a + b;
            }
            catch (OverflowException)
            {
                return ((double)a + (double)b > 0.0) ? long.MaxValue : long.MinValue;
            }
        }

        public static int av_sat_dadd32_c(int a, int b)
        {
            return av_sat_add32_c(a, av_sat_add32_c(b, b));
        }

        public static int av_sat_dsub32_c(int a, int b)
        {
            return av_sat_sub32_c(a, av_sat_add32_c(b, b));
        }

        public static int av_sat_sub32_c(int a, int b)
        {
            return av_clipl_int32_c((long)a - (long)b);
        }

        public static long av_sat_sub64_c(long a, long b)
        {
            try
            {
                return a - b;
            }
            catch (OverflowException)
            {
                return ((double)a - (double)b > 0.0) ? long.MaxValue : long.MinValue;
            }
        }

        public unsafe static void* av_x_if_null(void* p, void* x)
        {
            if (p == null)
            {
                return x;
            }

            return p;
        }

        public unsafe static long avio_tell(AVIOContext* s)
        {
            return avio_seek(s, 0L, 1);
        }

        public static AVChannelLayout AV_CHANNEL_LAYOUT_MASK(int nb, ulong m)
        {
            return new AVChannelLayout
            {
                order = AVChannelOrder.AV_CHANNEL_ORDER_NATIVE,
                nb_channels = nb,
                u = new AVChannelLayout_u
                {
                    mask = m
                }
            };
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate SwrContext* D_swr_alloc();

        private static D_swr_alloc d_swr_alloc;

        public unsafe static SwrContext* swr_alloc() =>
            (d_swr_alloc ?? (d_swr_alloc = NativeBindings.Get<D_swr_alloc>("swresample", "swr_alloc")))();

        [DllImport("swresample", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use ")]
        public unsafe static extern SwrContext* swr_alloc_set_opts(SwrContext* s, long out_ch_layout,
            AVSampleFormat out_sample_fmt, int out_sample_rate, long in_ch_layout, AVSampleFormat in_sample_fmt,
            int in_sample_rate, int log_offset, void* log_ctx);


        [DllImport("swresample", CallingConvention = CallingConvention.Cdecl)]
        [Obsolete("use ")]
        public unsafe static extern int swr_build_matrix(ulong in_layout, ulong out_layout, double center_mix_level,
            double surround_mix_level, double lfe_mix_level, double rematrix_maxval, double rematrix_volume,
            double* matrix,
            int stride, AVMatrixEncoding matrix_encoding, void* log_ctx);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_swr_convert(SwrContext* s, byte** @out, int out_count, byte** @in, int in_count);

        private static D_swr_convert d_swr_convert;

        public unsafe static int swr_convert(SwrContext* s, byte** @out, int out_count, byte** @in, int in_count) =>
            (d_swr_convert ?? (d_swr_convert = NativeBindings.Get<D_swr_convert>("swresample", "swr_convert")))(s, @out,
                out_count, @in, in_count);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate long D_swr_get_delay(SwrContext* s, long @base);

        private static D_swr_get_delay d_swr_get_delay;

        public unsafe static long swr_get_delay(SwrContext* s, long @base) => (d_swr_get_delay ??
                                                                               (d_swr_get_delay =
                                                                                   NativeBindings.Get<D_swr_get_delay>(
                                                                                       "swresample", "swr_get_delay")))(
            s,
            @base);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_swr_init(SwrContext* s);

        private static D_swr_init d_swr_init;

        public unsafe static int swr_init(SwrContext* s) =>
            (d_swr_init ?? (d_swr_init = NativeBindings.Get<D_swr_init>("swresample", "swr_init")))(s);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint D_swresample_version();

        private static D_swresample_version d_swresample_version;

        public static uint swresample_version() => (d_swresample_version ?? (d_swresample_version =
            NativeBindings.Get<D_swresample_version>("swresample", "swresample_version")))();


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate void D_sws_freeContext(SwsContext* swsContext);

        private static D_sws_freeContext d_sws_freeContext;

        public unsafe static void sws_freeContext(SwsContext* swsContext) => (d_sws_freeContext ??
                                                                              (d_sws_freeContext =
                                                                                  NativeBindings.Get<D_sws_freeContext>(
                                                                                      "swscale", "sws_freeContext")))(
            swsContext);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate SwsContext* D_sws_getContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW,
            int dstH, AVPixelFormat dstFormat, int flags, SwsFilter* srcFilter, SwsFilter* dstFilter, double* param);

        private static D_sws_getContext d_sws_getContext;

        public unsafe static SwsContext* sws_getContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH,
            AVPixelFormat dstFormat, int flags, SwsFilter* srcFilter, SwsFilter* dstFilter, double* param) =>
            (d_sws_getContext ??
             (d_sws_getContext = NativeBindings.Get<D_sws_getContext>("swscale", "sws_getContext")))(
                srcW, srcH, srcFormat, dstW, dstH, dstFormat, flags, srcFilter, dstFilter, param);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private unsafe delegate int D_sws_scale(SwsContext* c, byte*[] srcSlice, int[] srcStride, int srcSliceY,
            int srcSliceH, byte*[] dst, int[] dstStride);

        private static D_sws_scale d_sws_scale;

        public unsafe static int sws_scale(SwsContext* c, byte*[] srcSlice, int[] srcStride, int srcSliceY,
            int srcSliceH,
            byte*[] dst, int[] dstStride) =>
            (d_sws_scale ?? (d_sws_scale = NativeBindings.Get<D_sws_scale>("swscale", "sws_scale")))(c, srcSlice,
                srcStride,
                srcSliceY, srcSliceH, dst, dstStride);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint D_swscale_version();

        private static D_swscale_version d_swscale_version;

        public static uint swscale_version() => (d_swscale_version ??
                                                 (d_swscale_version =
                                                     NativeBindings.Get<D_swscale_version>("swscale",
                                                         "swscale_version")))();
    }
}
