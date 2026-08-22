using System;
using System.Collections.Generic;
using System.Globalization;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.Vgmdb;

/// <inheritdoc />
public class VgmdbPlugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    public VgmdbPlugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    /// <summary>
    /// Gets the current plugin instance, so the API client can read the
    /// configured server URL.
    /// </summary>
    public static VgmdbPlugin Instance { get; private set; }

    /// <inheritdoc />
    public override string Name => "VGMdb (Self-hosted)";

    /// <inheritdoc />
    public override Guid Id => Guid.Parse("d5cbcac9-7bbc-4ae5-a8a2-62e9f392dfeb");

    /// <inheritdoc />
    public IEnumerable<PluginPageInfo> GetPages()
    {
        yield return new PluginPageInfo
        {
            // Deliberately not the display name: that carries spaces and
            // parentheses, which do not belong in a page identifier.
            Name = "Vgmdb",
            EmbeddedResourcePath = string.Format(
                CultureInfo.InvariantCulture,
                "{0}.Configuration.configPage.html",
                GetType().Namespace),
        };
    }
}
