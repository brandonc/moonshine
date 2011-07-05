DownBlouse
==========

> A .NET wrapper and win32 port of [upskirt][], the [markdown][] library

libupskirt.dll (included) is required for linkage. Also included is a simple console app for executing upskirt against markdown files.

DownBlouse is at least 20x faster than [MarkdownSharp][] when run against MarkdownSharp's own benchmark app.

![MarkdownSharp vs. DownBlouse](http://i.imgur.com/gIRuN.png)

    MarkdownSharp v1.13 benchmark, takes 10 ~ 30 seconds...

    input string length: 475
    4000 iterations in 2318 ms (0.5795 ms per iteration)
    input string length: 2356
    1000 iterations in 2396 ms (2.396 ms per iteration)
    input string length: 27737
    100 iterations in 2528 ms (25.28 ms per iteration)
    input string length: 11075
    1 iteration in 12 ms
    input string length: 88607
    1 iteration in 103 ms
    input string length: 354431
    1 iteration in 380 ms
    Benchmark completed in 7.752s


    DownBlouse v1.14.2 benchmark, takes 10 ~ 30 seconds...

    input string length: 475
    4000 iterations in 162 ms (0.0405 ms per iteration)
    input string length: 2356
    1000 iterations in 77 ms (0.077 ms per iteration)
    input string length: 27737
    100 iterations in 69 ms (0.69 ms per iteration)
    input string length: 11075
    1 iteration in 0 ms
    input string length: 88607
    1 iteration in 2 ms
    input string length: 354431
    1 iteration in 10 ms
    Benchmark completed in 0.333s

# Usage

    string html = DownBlouse.DownBlouse.Markdownify(input);

Or if you don't want [smartypants][] character encoding:

    string html = DownBlouse.DownBlouse.Markdownify(input, false);

# Thank You to Contributors

[jbevain][]: Markdown extensions

[upskirt]: https://github.com/tanoku/upskirt
[markdown]: http://daringfireball.net/projects/markdown
[smartypants]: http://daringfireball.net/projects/smartypants/
[MarkdownSharp]: http://code.google.com/p/markdownsharp/
[jbevain]: https://github.com/jbevain