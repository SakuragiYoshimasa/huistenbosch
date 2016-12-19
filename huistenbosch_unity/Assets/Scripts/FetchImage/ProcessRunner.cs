using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessRunner : MonoBehaviour {

    public void FetchImage() {
        var projectFolder = System.IO.Directory.GetCurrentDirectory();
        System.IO.Directory.SetCurrentDirectory("C:/Users/sakuragi/Desktop/twiapi");
        ProcessStart();

        System.IO.Directory.SetCurrentDirectory(projectFolder);
    }

    private void ProcessStart() {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = "node";
        process.StartInfo.Arguments = "scrape_instagram.js ハウステンボス";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OutputHandler);
        process.StartInfo.RedirectStandardError = true;
        process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ErrorOutputHanlder);
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.CreateNoWindow = true;
        process.EnableRaisingEvents = true;
        process.Exited += new System.EventHandler(Process_Exit);
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
    }

    public void FetchImageFromTwitter() {
        var projectFolder = System.IO.Directory.GetCurrentDirectory();
        System.IO.Directory.SetCurrentDirectory("C:/Users/sakuragi/Desktop/twiapi");
        FetchImageFromTwitter();

        System.IO.Directory.SetCurrentDirectory(projectFolder);
    }

    private void TwitterProcessStart() {
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.FileName = "node";
        process.StartInfo.Arguments = "scrape_instagram.js ハウステンボス";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OutputHandler);
        process.StartInfo.RedirectStandardError = true;
        process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ErrorOutputHanlder);
        process.StartInfo.RedirectStandardInput = false;
        process.StartInfo.CreateNoWindow = true;
        process.EnableRaisingEvents = true;
        process.Exited += new System.EventHandler(Process_Exit_Twitter);
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
    }

    private void OutputHandler(object sender, System.Diagnostics.DataReceivedEventArgs args)
    {
        if (!string.IsNullOrEmpty(args.Data))
        {
            Debug.Log(args.Data);
        }
    }
    private void ErrorOutputHanlder(object sender, System.Diagnostics.DataReceivedEventArgs args)
    {
        if (!string.IsNullOrEmpty(args.Data))
        {
            Debug.Log(args.Data);
        }
    }
    private void Process_Exit(object sender, System.EventArgs e)
    {
        System.Diagnostics.Process proc = (System.Diagnostics.Process)sender;
        Debug.Log("Process Finished");
        ImageLoadManager.I.FetchFinished = true;
        proc.Kill();
    }
    private void Process_Exit_Twitter(object sender, System.EventArgs e)
    {
        System.Diagnostics.Process proc = (System.Diagnostics.Process)sender;
        Debug.Log("Process Finished");
        ImageLoadManager.I.twitterFetchFinished = true;
        proc.Kill();
    }
}
