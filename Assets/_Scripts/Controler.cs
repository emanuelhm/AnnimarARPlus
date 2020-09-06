using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Controler : MonoBehaviour
{
    private readonly string _usuario = "";
    private readonly string _senha = "";

    public GameObject ModalSair;

    [Header("Login")]
    public InputField Usuario;
    public InputField Senha;
    public GameObject ModalLoginInvalido;

    [Header("Telas")]
    public GameObject TelaLogin;
    public GameObject TelaPrincipal;

    [Header("Help")]
    private int _helpIndex;
    public Button HelpButton;
    public GameObject[] TelasHelp;

    [Header("Menu")]
    public Animator MenuAnimator;

    [Header("Foto")]
    public GameObject ModalFoto;
    public GameObject Canvas;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ModalSair.SetActive(true);
        }
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Login()
    {
        if (Usuario.text == _usuario && Senha.text == _senha)
        {
            TelaLogin.SetActive(false);
            TelaPrincipal.SetActive(true);
        }
        else
        {
            ModalLoginInvalido.SetActive(true);
        }
    }

    public void Help()
    {
        _helpIndex = 0;
        TelasHelp[_helpIndex].SetActive(true);
    }

    public void NextHelp()
    {
        TelasHelp[_helpIndex].SetActive(false);
        _helpIndex++;
        TelasHelp[_helpIndex].SetActive(true);
    }

    public void PreviousHelp()
    {
        TelasHelp[_helpIndex].SetActive(false);
        _helpIndex--;
        TelasHelp[_helpIndex].SetActive(true);
    }

    public void CloseHelp()
    {
        TelasHelp[_helpIndex].SetActive(false);
    }

    public void OpenMenu()
    {
        MenuAnimator.enabled = true;
        MenuAnimator.SetBool("IsOpened", true);
    }

    public void CloseMenu()
    {
        MenuAnimator.SetBool("IsOpened", false);
    }

    public void TakeScreenShot()
    {
        StartCoroutine(CaptureImageCoroutine());
    }

    private IEnumerator CaptureImageCoroutine()
    {
        Canvas.SetActive(false);

        if (NativeGallery.CheckPermission() != NativeGallery.Permission.Granted)
        {
            yield return new WaitWhile(() =>
            {
                NativeGallery.RequestPermission();

                return false;
            });
        }

        yield return new WaitForEndOfFrame();

        float offset = 90 * Screen.height / 923.7603f;

        var image = new Texture2D(Screen.width, Screen.height - (int)Math.Floor(offset), TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, offset, Screen.width, Screen.height), 0, 0);
        image.Apply();

        byte[] data = image.EncodeToPNG();

        NativeGallery.Permission imageResult = NativeGallery.Permission.Denied;

        try
        {
            string ImageFileName = Application.productName + "_Image{0}.png";

            if (!Application.isEditor)
            {
                imageResult = NativeGallery.SaveImageToGallery(data, Application.productName, ImageFileName);
            }

            if (imageResult != NativeGallery.Permission.Granted)
            {
                NativeGallery.RequestPermission();
            }
        }
        catch (Exception e) { }

        Canvas.SetActive(true);

        ModalFoto.SetActive(true);
    }
}