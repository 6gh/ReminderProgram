using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace ReminderProgram
{
    public class Updates
    {
        public static async void Check(bool ranOnStartup=false)
        {
            try
            {
                //get github releases
                GitHubClient client = new GitHubClient(new ProductHeaderValue("ReminderProgram"));
                IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("6gh", "ReminderProgram");

                //versions
                Version latestGitHubVersion = new Version(releases[0].TagName);
                Version localVersion = new Version(Properties.Settings.Default.Version);

                //compare
                int verComparison = localVersion.CompareTo(latestGitHubVersion);
                if (verComparison < 0)
                {
                    //github version > local 
                    //(out of date)

                    Debugger.Log("Updater", "Out of date");
                    Form1.versions2toolstrip.Text = "Out of date";

                    if (Properties.Settings.Default.CheckForUpdates || !ranOnStartup)
                    {
                        DialogResult result = MessageBox.Show("There is a new version on GitHub. Do you want to open the GitHub Page?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://www.github.com/6gh/ReminderProgram");
                        }
                    }
                }
                else if (verComparison > 0)
                {
                    //local > github version
                    //(beta)

                    Debugger.Log("Updater", "This is a beta release");
                    Form1.versions2toolstrip.Text = "Beta Release";
                    MessageBox.Show("This is a Beta Version. This update will contain new features but at the cost of bugs being encountered.\nPlease use the latest release for the best stability.", "Beta Release", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //github version = local
                    //same version

                    Debugger.Log("Updater", "Up to date");
                    Form1.versions2toolstrip.Text = "Up to date";
                }
            } catch (Exception e)
            {
                Debugger.Error("Updates", e.Message);
                Form1.versions2toolstrip.Text = "N/A";
                if (Properties.Settings.Default.CheckForUpdates || !ranOnStartup)
                {
                    DialogResult result = MessageBox.Show($"Couldn't check for updates\n\n{e.Message}", "Updates", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (result == DialogResult.Retry) Check(ranOnStartup);
                }
            }
        }
    }
}
