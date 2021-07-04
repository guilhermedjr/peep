defmodule MediaServer.PeepMediaContentTest do
  use MediaServer.DataCase

  alias MediaServer.PeepMediaContent

  describe "peep_media" do
    alias MediaServer.PeepMediaContent.PeepMedia

    @valid_attrs %{index: 42, media: "some media", media_type: 42, peep: "7488a646-e31f-11e4-aace-600308960662"}
    @update_attrs %{index: 43, media: "some updated media", media_type: 43, peep: "7488a646-e31f-11e4-aace-600308960668"}
    @invalid_attrs %{index: nil, media: nil, media_type: nil, peep: nil}

    def peep_media_fixture(attrs \\ %{}) do
      {:ok, peep_media} =
        attrs
        |> Enum.into(@valid_attrs)
        |> PeepMediaContent.create_peep_media()

      peep_media
    end

    test "list_peep_media/0 returns all peep_media" do
      peep_media = peep_media_fixture()
      assert PeepMediaContent.list_peep_media() == [peep_media]
    end

    test "get_peep_media!/1 returns the peep_media with given id" do
      peep_media = peep_media_fixture()
      assert PeepMediaContent.get_peep_media!(peep_media.id) == peep_media
    end

    test "create_peep_media/1 with valid data creates a peep_media" do
      assert {:ok, %PeepMedia{} = peep_media} = PeepMediaContent.create_peep_media(@valid_attrs)
      assert peep_media.index == 42
      assert peep_media.media == "some media"
      assert peep_media.media_type == 42
      assert peep_media.peep == "7488a646-e31f-11e4-aace-600308960662"
    end

    test "create_peep_media/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = PeepMediaContent.create_peep_media(@invalid_attrs)
    end

    test "update_peep_media/2 with valid data updates the peep_media" do
      peep_media = peep_media_fixture()
      assert {:ok, %PeepMedia{} = peep_media} = PeepMediaContent.update_peep_media(peep_media, @update_attrs)
      assert peep_media.index == 43
      assert peep_media.media == "some updated media"
      assert peep_media.media_type == 43
      assert peep_media.peep == "7488a646-e31f-11e4-aace-600308960668"
    end

    test "update_peep_media/2 with invalid data returns error changeset" do
      peep_media = peep_media_fixture()
      assert {:error, %Ecto.Changeset{}} = PeepMediaContent.update_peep_media(peep_media, @invalid_attrs)
      assert peep_media == PeepMediaContent.get_peep_media!(peep_media.id)
    end

    test "delete_peep_media/1 deletes the peep_media" do
      peep_media = peep_media_fixture()
      assert {:ok, %PeepMedia{}} = PeepMediaContent.delete_peep_media(peep_media)
      assert_raise Ecto.NoResultsError, fn -> PeepMediaContent.get_peep_media!(peep_media.id) end
    end

    test "change_peep_media/1 returns a peep_media changeset" do
      peep_media = peep_media_fixture()
      assert %Ecto.Changeset{} = PeepMediaContent.change_peep_media(peep_media)
    end
  end
end
