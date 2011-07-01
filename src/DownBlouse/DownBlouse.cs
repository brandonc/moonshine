using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DownBlouse {
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    struct buf {
        [MarshalAs(UnmanagedType.LPStr)]
	    public string data;	    /* actual character data */
        public uint size;	    /* size of the string */
        public uint asize;	    /* allocated size (0 = volatile buffer) */
        public uint unit;	    /* reallocation unit size (0 = read-only buffer) */
        public int @ref;        /* reference count */
    };

    enum mkd_autolink {
        MKDA_NOT_AUTOLINK,
        MKDA_NORMAL,
        MKDA_EMAIL,
    }

    delegate void mkd_renderer_blockcode(ref buf ob, ref buf text, ref buf lang, System.IntPtr opaque);

    delegate void mkd_renderer_blockquote(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate void mkd_renderer_blockhtml(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate void mkd_renderer_header(ref buf ob, ref buf text, int level, System.IntPtr opaque);

    delegate void mkd_renderer_hrule(ref buf ob, System.IntPtr opaque);

    delegate void mkd_renderer_list(ref buf ob, ref buf text, int flags, System.IntPtr opaque);

    delegate void mkd_renderer_listitem(ref buf ob, ref buf text, int flags, System.IntPtr opaque);

    delegate void mkd_renderer_paragraph(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate void mkd_renderer_table(ref buf ob, ref buf header, ref buf body, System.IntPtr opaque);

    delegate void mkd_renderer_table_row(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate void mkd_renderer_table_cell(ref buf ob, ref buf text, int flags, System.IntPtr opaque);

    delegate int mkd_renderer_autolink(ref buf ob, ref buf link, mkd_autolink type, System.IntPtr opaque);

    delegate int mkd_renderer_codespan(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate int mkd_renderer_double_emphasis(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate int mkd_renderer_emphasis(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate int mkd_renderer_image(ref buf ob, ref buf link, ref buf title, ref buf alt, System.IntPtr opaque);

    delegate int mkd_renderer_linebreak(ref buf ob, System.IntPtr opaque);

    delegate int mkd_renderer_link(ref buf ob, ref buf link, ref buf title, ref buf content, System.IntPtr opaque);

    delegate int mkd_renderer_raw_html_tag(ref buf ob, ref buf tag, System.IntPtr opaque);

    delegate int mkd_renderer_triple_emphasis(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate int mkd_renderer_strikethrough(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate void mkd_renderer_entity(ref buf ob, ref buf entity, System.IntPtr opaque);

    delegate void mkd_renderer_normal_text(ref buf ob, ref buf text, System.IntPtr opaque);

    delegate void mkd_renderer_doc_header(ref buf ob, System.IntPtr opaque);

    delegate void mkd_renderer_doc_footer(ref buf ob, System.IntPtr opaque);

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    struct mkd_renderer {
        public mkd_renderer_blockcode blockcode;

        public mkd_renderer_blockquote blockquote;

        public mkd_renderer_blockhtml blockhtml;

        public mkd_renderer_header header;

        public mkd_renderer_hrule hrule;

        public mkd_renderer_list list;

        public mkd_renderer_listitem listitem;

        public mkd_renderer_paragraph paragraph;

        public mkd_renderer_table table;

        public mkd_renderer_table_row table_row;

        public mkd_renderer_table_cell table_cell;

        public mkd_renderer_autolink autolink;

        public mkd_renderer_codespan codespan;

        public mkd_renderer_double_emphasis double_emphasis;

        public mkd_renderer_emphasis emphasis;

        public mkd_renderer_image image;

        public mkd_renderer_linebreak linebreak;
        
        public mkd_renderer_link link;

        public mkd_renderer_raw_html_tag raw_html_tag;

        public mkd_renderer_triple_emphasis triple_emphasis;

        public mkd_renderer_strikethrough strikethrough;

        public mkd_renderer_entity entity;

        public mkd_renderer_normal_text normal_text;

        public mkd_renderer_doc_header doc_header;

        public mkd_renderer_doc_footer doc_footer;

        // void*
        public IntPtr opaque;
    }

    [Flags]
    public enum MarkdownExtensions {
        None = 0,
        NoIntraEmphasis = 1 << 0,
        Tables = 1 << 1,
        FencedCode = 1 << 2,
        AutoLink = 1 << 3,
        StrikeThrough = 1 << 4,
        LaxHtmlBlocks = 1 << 5,
        SpaceHeaders = 1 << 6,
	}

    public class DownBlouse {
        [DllImport("libupskirt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void upshtml_renderer(ref mkd_renderer renderer, uint render_flags);

        [DllImport("libupskirt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void upshtml_free_renderer(ref mkd_renderer renderer);

        [DllImport("libupskirt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void upshtml_smartypants(IntPtr ob, IntPtr text);

        [DllImport("libupskirt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ups_markdown(IntPtr ob, ref buf ib, ref mkd_renderer renderer, uint extensions);

        [DllImport("libupskirt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ups_version(ref int ver_major, ref int ver_minor, ref int ver_revision);

        [DllImport("libupskirt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void bufrelease(IntPtr buf);

        [DllImport("libupskirt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr bufnew(uint size);

        public static string UpskirtVersion()
        {
            int maj = 0, min = 0, rev = 0;
            ups_version(ref maj, ref min, ref rev);
            return String.Format("{0}.{1}.{2}", maj, min, rev);
        }

#if NET_3_5
        public static string Markdownify(string s) {
            return Markdownify(s, true);
        }

        public static string Markdownify(string s, MarkdownExtensions extensions) {
            return Markdownify(s, extensions, true);
        }

        public static string Markdownify(string s, bool smartypants) {
            return Markdownify(s, MarkdownExtensions.None, smartypants);
        }

        public static string Markdownify(string s, MarkdownExtensions extensions, bool smartypants) {
#else
        public static string Markdownify(string s, MarkdownExtensions extensions = MarkdownExtensions.None, bool smartypants = true) {
#endif
            mkd_renderer renderer = new mkd_renderer();

            buf input;
            input.data = s;
            input.size = (uint)s.Length;
            input.asize = (uint)Math.Max(1024, s.Length);
            input.unit = 1024;
            input.@ref = 1;
            
            IntPtr poutput = bufnew(64);

            upshtml_renderer(ref renderer, (uint)0);
            ups_markdown(poutput, ref input, ref renderer, (uint)extensions);
            upshtml_free_renderer(ref renderer);

            buf output;

            if (smartypants) {
                IntPtr psmarty = bufnew(128);
                upshtml_smartypants(psmarty, poutput);
                output = (buf)Marshal.PtrToStructure(psmarty, typeof(buf));
                bufrelease(psmarty);
            } else {
                output = (buf)Marshal.PtrToStructure(poutput, typeof(buf));
            }

            bufrelease(poutput);

            string result = String.Empty;

            if (output.data != null)
                result = output.data.Substring(0, (int)output.size);

            return result;
                
        }
    }
}
