// FFmpegOut - FFmpeg video encoding plugin for Unity
// https://github.com/keijiro/KlakNDI

namespace FFmpegOut
{
    public enum FFmpegPreset
    {
        H264Default,
        H264Lossless420,
        H264Lossless444,
        H265Default,
        ProRes422,
        ProRes4444,
        VP8Default,
        VP9Default
    }

    static public class FFmpegPresetExtensions
    {
        public static string GetDisplayName(this FFmpegPreset preset)
        {
            switch (preset)
            {
                case FFmpegPreset.H264Default:     return "H.264 Default (MP4)";
                case FFmpegPreset.H264Lossless420: return "H.264 Lossless 420 (MP4)";
                case FFmpegPreset.H264Lossless444: return "H.264 Lossless 444 (MP4)";
                case FFmpegPreset.H265Default:     return "H.265 Default (MP4)";
                case FFmpegPreset.ProRes422:       return "ProRes 422 (QuickTime)";
                case FFmpegPreset.ProRes4444:      return "ProRes 4444 (QuickTime)";
                case FFmpegPreset.VP8Default:      return "VP8 (WebM)";
                case FFmpegPreset.VP9Default:      return "VP9 (WebM)";
            }
            return null;
        }

        public static string GetSuffix(this FFmpegPreset preset)
        {
            switch (preset)
            {
                case FFmpegPreset.H264Default:
                case FFmpegPreset.H264Lossless420:
                case FFmpegPreset.H264Lossless444:
                case FFmpegPreset.H265Default:     return ".mp4";
                case FFmpegPreset.ProRes422:
                case FFmpegPreset.ProRes4444:      return ".mov";
                case FFmpegPreset.VP9Default:
                case FFmpegPreset.VP8Default:      return ".webm";
            }
            return null;
        }

        public static string GetOptions(this FFmpegPreset preset)
        {
            switch (preset)
            {
                case FFmpegPreset.H264Default:     return "-pix_fmt yuv420p";
                case FFmpegPreset.H264Lossless420: return "-pix_fmt yuv420p -preset ultrafast -crf 0";
                case FFmpegPreset.H264Lossless444: return "-pix_fmt yuv444p -preset ultrafast -crf 0";
                case FFmpegPreset.H265Default:     return "-c:v libx265 -pix_fmt yuv420p";
                case FFmpegPreset.ProRes422:       return "-c:v prores_ks -pix_fmt yuv422p10le";
                case FFmpegPreset.ProRes4444:      return "-c:v prores_ks -pix_fmt yuva444p10le";
                case FFmpegPreset.VP8Default:      return "-c:v libvpx -pix_fmt yuv420p";
                case FFmpegPreset.VP9Default:      return "-c:v libvpx-vp9";
            }
            return null;
        }
    }
}
