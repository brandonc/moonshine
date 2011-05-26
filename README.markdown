# DownBlouse #

*A .NET wrapper and win32 port of upskirt, a [markdown][] library*

# Usage

    string html = DownBlouse.DownBlouse.Markdownify(input);

Or if you don't want smartypants[1] character encoding:

    string html = DownBlouse.DownBlouse.Markdownify(input, false);

[markdown]: http://daringfireball.net/projects/markdown