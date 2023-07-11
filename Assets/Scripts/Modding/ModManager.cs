using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ModManager : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] private GameObject _modTogglePrefab;
    
    public readonly string ModFolderPath = Application.streamingAssetsPath + "/Mods/";
    private const string TowersJsonFileName = "towers.json";
    private const string EnemiesJsonFileName = "enemies.json";
    private const string WavesJsonFileName = "waves.json";
    private const string BaseJsonFileName = "base.json";

    private readonly List<GameObject> _modToggles = new ();
    private Dictionary<string, bool> _previousMods = new ();

    private void Start()
    {
        _previousMods = ModList.Mods.ToDictionary(mod => mod.Key, mod => mod.Value);
        InitFolder();
        RefreshMods();
    }

    public void RefreshMods()
    {
        ReadMods();
        DisplayMods();
    }

    private void InitFolder()
    {
        Directory.CreateDirectory(ModFolderPath);
    }
    
    private void ReadMods()
    {
        _modToggles.ForEach(Destroy);
        
        var modFolders = Directory.GetDirectories(ModFolderPath);
        
        foreach (var modFolder in modFolders)
        {
            if (!ModList.Mods.ContainsKey(modFolder))
                ModList.Mods.Add(modFolder, false);
        }

        var modsToRemove = ModList.Mods.Where(mod => !modFolders.Contains(mod.Key)).ToList();
        modsToRemove.ForEach(mod => ModList.Mods.Remove(mod.Key));
    }
    
    private void DisplayMods()
    {
        foreach (var modPath in ModList.Mods.Keys)
        {
            var obj = Instantiate(_modTogglePrefab, _panel);
            _modToggles.Add(obj);
            if (!obj.TryGetComponent(out ModToggle modToggle)) throw new Exception("The prefab does not have the ModToggle.cs script attached.");

            
            modToggle.Toggle.isOn = ModList.Mods[modPath];
            modToggle.Label.text = ConvertPathToName(modPath);
            modToggle.Path = modPath;
            modToggle.ValueChanged += OnToggleMod;
        }
    }

    private void OnToggleMod(string key, bool status)
    {
        ModList.Mods[key] = status;
    }

    public void CancelSelection()
    {
        ModList.Mods = _previousMods.ToDictionary(mod => mod.Key, mod => mod.Value);
    }

    public void ApplyMods()
    {
        _previousMods = ModList.Mods.ToDictionary(mod => mod.Key, mod => mod.Value);
        foreach (var mod in ModList.Mods)
        {
            if (!mod.Value) continue;
                
            OpenMod(mod.Key);
        }
    }

    private void OpenMod(string modPath)
    {
        var files = Directory.EnumerateFiles(modPath)
            .Where(file => file.ToLower().EndsWith(".json") || file.ToLower().EndsWith(".lua")).ToList();
        
        OpenModFiles(files);
    }

    private void OpenModFiles(List<string> modFiles)
    {
        foreach (var file in modFiles)
        {
            var filename = Path.GetFileName(file);

            var jsonString = OpenJsonFile(file);
            
            switch (filename)
            {
                case TowersJsonFileName:
                    // TODO: Call1
                    continue;
                case EnemiesJsonFileName:
                    // TODO: Call2
                    return;
                case WavesJsonFileName:
                    // TODO: Call3
                    return;
                case BaseJsonFileName:
                    // TODO: Call4
                    return;
            }
        }
    }
    
    private string OpenJsonFile(string filePath)
    {
        using var streamReader = new StreamReader(filePath);
        var json = streamReader.ReadToEnd();

        return json;
    }

    private void OpenLuaFile(string filePath)
    {
        Debug.Log($"OPEN {filePath}");
    }

    private string ConvertPathToName(string path)
    {
        return Path.GetFileName(Path.GetDirectoryName(path +"/"));
    }
}