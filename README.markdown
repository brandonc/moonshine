# DownBlouse #

*A .NET wrapper and win32 port of [upskirt][], a [markdown][] library*

# Usage

    string html = DownBlouse.DownBlouse.Markdownify(input);

Or if you don't want [smartypants][] character encoding:

    string html = DownBlouse.DownBlouse.Markdownify(input, false);

[upskirt]: https://github.com/tanoku/upskirt
[markdown]: http://daringfireball.net/projects/markdown
[smartypants]: http://daringfireball.net/projects/smartypants/
